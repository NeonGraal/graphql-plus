
using Fluid;
using Fluid.Values;
using GqlPlus;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus.Convert;

public static class RenderFluid
{
  private static readonly FluidParser s_parser = new();
  private static readonly TemplateOptions s_options = new();
  private static readonly Map<IFluidTemplate> s_templates = [];

  static RenderFluid()
    => s_options.ValueConverters.Add(RenderConverter);

  public static void Setup(IFileProvider provider)
  {
    s_options.FileProvider = provider;
    s_options.Filters.AddFilter("tag", TagFilter);
  }

  private static IFluidTemplate GetTemplate(string template)
  {
    lock (s_templates) {
      return s_templates.GetValueOrCreate(template,
        k => s_parser.Parse("{% render '" + k + "' %}")
          ?? throw new InvalidOperationException($"Failed to parse template '{k}'"));
    }
  }

  private static ValueTask<FluidValue> TagFilter(FluidValue input, FilterArguments arguments, TemplateContext context)
    => input is TaggedValue tagged
      ? new StringValue(tagged.Tag)
      : EmptyValue.Instance;

  internal static IGqlpValue Links(this IEnumerable<string> list, Func<string, string> mapper)
    => new GqlpMap(list.Select(i => new KeyValuePair<IGqlpScalar, IGqlpValue>(
      new GqlpScalar(mapper(i), isIdentifier: mapper(i).IsIdentifier()), i.Encode())), "links");

  internal static IGqlpValue Links(this IEnumerable<string> list, string prefix = "")
    => new GqlpMap(list.Select(i => new KeyValuePair<IGqlpScalar, IGqlpValue>(
      new GqlpScalar(i, isIdentifier: i.IsIdentifier()), (prefix + i).Encode())), "links");

  internal static Map<IGqlpValue> Links(this Map<IEnumerable<string>> groups)
    => groups.ToMap(g => g.Key, g => g.Value.Links(g.Key + "/"));

  internal static async Task WriteHtmlFileAsync(this IGqlpValue model, string dir, string file, string initial = "default")
  {
    ArgumentNullException.ThrowIfNull(model);

    TemplateContext context = new(model.Add("yaml", model.ToSimpleYaml(true).Joined(Environment.NewLine).Encode()), s_options);
    IFluidTemplate template = GetTemplate(initial);
    await template.RenderAsync(context).WriteHtmlFileAsync(dir, file);
  }

  private static object RenderConverter(object input)
    => input is IGqlpValue model ? RenderStructureConverter(model)
      : input is GqlpScalar value ? RenderValueConverter(value)
      : input;

  private static FluidValue RenderStructureConverter(IGqlpValue model)
  {
    FluidValue result = EmptyValue.Instance;

    if (model is GqlpList list) {
      result = new ArrayValue([.. list.Items.Select(RenderStructureConverter)]);
    } else if (model is GqlpMap map) {
      Dictionary<string, FluidValue> dict = map.Entries
        .ToDictionary(
          kv => kv.Key.Text ?? kv.Key.ToString() ?? "",
          kv => RenderStructureConverter(kv.Value)
        );

      result = new DictionaryValue(new FluidValueDictionaryFluidIndexable(dict));
    } else if (model is IGqlpScalar value) {
      result = RenderValueConverter(value);
    }

    return string.IsNullOrWhiteSpace(model.Tag) ? result
      : new TaggedValue(model.Tag, result);
  }

  private static FluidValue RenderValueConverter(IGqlpScalar value)
  {
    FluidValue result = EmptyValue.Instance;

    result = value.Kind switch {
      GqlpScalarKind.Boolean => BooleanValue.Create(value.BooleanValue!.Value),
      GqlpScalarKind.Number => NumberValue.Create(value.Number!.Value),
      _ => StringValue.Create(value.Text ?? ""),
    };

    return string.IsNullOrWhiteSpace(value.Tag) ? result
      : new TaggedValue(value.Tag, result);
  }

  public static void CheckFluidFiles()
  {
    IFileProvider files = s_options.FileProvider;

    IDirectoryContents contents = files.GetDirectoryContents("");

    contents.ShouldSatisfyAllConditions(
      c => c.Exists.ShouldBeTrue(),
      c => c.ShouldNotBeEmpty(),
      c => c.ShouldContain(fi => fi.Name == "pico.liquid"));
  }
}

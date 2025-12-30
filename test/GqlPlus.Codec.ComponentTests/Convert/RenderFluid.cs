
using Fluid;
using Fluid.Values;

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
      if (!s_templates.TryGetValue(template, out IFluidTemplate? value)) {
        value = s_parser.Parse("{% render '" + template + "' %}");
        s_templates.Add(template, value);
      }

      return value;
    }
  }

  private static ValueTask<FluidValue> TagFilter(FluidValue input, FilterArguments arguments, TemplateContext context)
    => input is TaggedValue tagged
      ? new StringValue(tagged.Tag)
      : EmptyValue.Instance;

  internal static Structured Links(this IEnumerable<string> list, Func<string, string> mapper)
    => new(list.ToDictionary(i => new StructureValue(mapper(i)), i => new Structured(i)), "links");

  internal static Structured Links(this IEnumerable<string> list, string prefix = "")
    => new(list.ToDictionary(i => new StructureValue(i), i => new Structured(prefix + i)), "links");

  internal static Map<Structured> Links(this Map<IEnumerable<string>> groups)
    => groups.ToMap(g => g.Key, g => g.Value.Links(g.Key + "/"));

  internal static async Task WriteHtmlFileAsync(this Structured model, string dir, string file, string initial = "default")
  {
    ArgumentNullException.ThrowIfNull(model);

    model.Add("yaml", model.ToSimpleYaml(true).Joined(Environment.NewLine));
    TemplateContext context = new(model, s_options);
    IFluidTemplate template = GetTemplate(initial);
    await template.RenderAsync(context).WriteHtmlFileAsync(dir, file);
  }

  private static object RenderConverter(object input)
    => input is Structured model ? RenderStructureConverter(model)
      : input is StructureValue value ? RenderValueConverter(value)
      : input;

  private static FluidValue RenderStructureConverter(Structured model)
  {
    FluidValue result = EmptyValue.Instance;

    if (model.List.Count > 0) {
      result = new ArrayValue([.. model.List.Select(RenderStructureConverter)]);
    } else if (model.Map.Count > 0) {
      Dictionary<string, FluidValue> dict = model.Map
        .ToDictionary(
          kv => kv.Key.AsString,
          kv => RenderStructureConverter(kv.Value)
        );

      result = new DictionaryValue(new FluidValueDictionaryFluidIndexable(dict));
    } else if (model.Value is not null) {
      result = RenderValueConverter(model.Value);

      if (result is TaggedValue) {
        return result;
      }
    }

    return string.IsNullOrWhiteSpace(model.Tag) ? result
      : new TaggedValue(model.Tag, result);
  }

  private static FluidValue RenderValueConverter(StructureValue value)
  {
    FluidValue result = EmptyValue.Instance;

    if (value.Identifier is not null) {
      result = StringValue.Create(value.Identifier);
    }

    if (value.Boolean is not null) {
      result = BooleanValue.Create(value.Boolean.Value);
    }

    if (value.Number is not null) {
      result = NumberValue.Create(value.Number.Value);
    }

    if (value.Text is not null) {
      result = StringValue.Create(value.Text);
    }

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

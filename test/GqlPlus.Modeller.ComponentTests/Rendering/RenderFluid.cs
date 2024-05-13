using Fluid;
using Fluid.Values;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus.Rendering;

public static class RenderFluid
{
  private static readonly FluidParser s_parser = new();
  private static readonly TemplateOptions s_options = new();
  private static readonly string s_projectDir = AttributeReader.GetProjectDirectory();
  private static IFluidTemplate? s_template;

  static RenderFluid()
    => s_options.ValueConverters.Add(RenderConverter);

  public static void Setup(IFileProvider provider, string template = "default")
  {
    s_options.FileProvider = provider;
    s_options.Filters.AddFilter("tag", TagFilter);
    s_template = s_parser.Parse("{% render '" + template + "' %}");
  }

  private static ValueTask<FluidValue> TagFilter(FluidValue input, FilterArguments arguments, TemplateContext context)
    => input is TaggedValue tagged
      ? new StringValue(tagged.Tag)
      : EmptyValue.Instance;

  public static async Task<string> ToFluid(this RenderStructure model)
  {
    ArgumentNullException.ThrowIfNull(model);

    model.Add("yaml", model.ToYaml());
    TemplateContext context = new(model, s_options);
    return await s_template.RenderAsync(context);
  }

  internal static async Task WriteHtmlFile(string dir, string file, RenderStructure result)
  {
    string dirPath = Path.Join(s_projectDir, dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    await File.WriteAllTextAsync(filePath, await result.ToFluid());
  }

  private static object RenderConverter(object input)
    => input is RenderStructure model ? RenderStructureConverter(model)
      : input is RenderValue value ? RenderValueConverter(value)
      : input;

  private static FluidValue RenderStructureConverter(RenderStructure model)
  {
    FluidValue result = NilValue.Empty;

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

  private static FluidValue RenderValueConverter(RenderValue value)
  {
    FluidValue result = NilValue.Empty;

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
}

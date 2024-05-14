using Fluid;
using Fluid.Values;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus.Rendering;

public static class RenderFluid
{
  private static readonly FluidParser s_parser = new();
  private static readonly TemplateOptions s_options = new();
  private static readonly string s_projectDir = AttributeReader.GetProjectDirectory();
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
    if (!s_templates.TryGetValue(template, out IFluidTemplate? value)) {
      value = s_parser.Parse("{% render '" + template + "' %}");
      s_templates.Add(template, value);
    }

    return value;
  }

  private static ValueTask<FluidValue> TagFilter(FluidValue input, FilterArguments arguments, TemplateContext context)
    => input is TaggedValue tagged
      ? new StringValue(tagged.Tag)
      : EmptyValue.Instance;

  internal static void WriteHtmlFile(this RenderStructure model, string dir, string file, string initial = "default")
  {
    ArgumentNullException.ThrowIfNull(model);

    model.Add("yaml", model.ToYaml(true));
    TemplateContext context = new(model, s_options);

    string dirPath = Path.Join(s_projectDir, dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    IFluidTemplate template = GetTemplate(initial);
    File.WriteAllText(filePath, template.Render(context));
  }

  internal static async Task WriteHtmlFileAsync(string dir, string file, RenderStructure model, string initial = "default")
  {
    ArgumentNullException.ThrowIfNull(model);

    model.Add("yaml", model.ToYaml(true));
    TemplateContext context = new(model, s_options);

    string dirPath = Path.Join(s_projectDir, dir);
    if (!Directory.Exists(dirPath)) {
      Directory.CreateDirectory(dirPath);
    }

    string filePath = Path.Join(dirPath, file + ".html");
    IFluidTemplate template = GetTemplate(initial);
    await File.WriteAllTextAsync(filePath, await template.RenderAsync(context));
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

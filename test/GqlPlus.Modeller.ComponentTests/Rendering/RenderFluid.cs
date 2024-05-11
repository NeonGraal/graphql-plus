using Fluid;
using Fluid.Values;
using Microsoft.Extensions.FileProviders;

namespace GqlPlus.Rendering;

public static class RenderFluid
{
  private static readonly FluidParser s_parser = new();
  private readonly static TemplateOptions s_options = new();
  private static readonly string s_projectDir = AttributeReader.GetProjectDirectory();
  private static IFluidTemplate? s_template;

  static RenderFluid()
    => s_options.ValueConverters.Add(RenderConverter);

  public static void Setup(IFileProvider provider, string template = "default")
  {
    s_options.FileProvider = provider;
    s_template = s_parser.Parse("{% render '" + template + "' %}");
  }

  public async static Task<string> ToFluid(this RenderStructure model)
  {
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
    if (model.List.Count > 0) {
      return new ArrayValue(model.List.Select(RenderStructureConverter));
    }

    if (model.Map.Count > 0) {
      Dictionary<string, FluidValue> dict = model.Map
        .ToDictionary(
          kv => kv.Key.AsString,
          kv => RenderStructureConverter(kv.Value)
        );
      if (!string.IsNullOrWhiteSpace(model.Tag)) {
        dict["_tag"] = StringValue.Create(model.Tag);
      }

      return new DictionaryValue(new FluidValueDictionaryFluidIndexable(dict));
    }

    if (model.Value is not null) {
      return RenderValueConverter(model.Value);
    }

    return NilValue.Empty;
  }

  private static FluidValue RenderValueConverter(RenderValue value)
  {
    if (value.Identifier is not null) {
      return StringValue.Create(value.Identifier);
    }

    if (value.Boolean is not null) {
      return BooleanValue.Create(value.Boolean.Value);
    }

    if (value.Number is not null) {
      return NumberValue.Create(value.Number.Value);
    }

    if (value.Text is not null) {
      return StringValue.Create(value.Text);
    }

    return NilValue.Empty;
  }
}

using System.Reflection.Emit;
using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Convert;
using GqlPlus.Resolving;

namespace GqlPlus;

[Trait("Generate", "Html")]
public class HtmlBuiltInTests(IModelAndEncode encoder)
{
  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public async Task HtmlBasicTypes(string type)
    => await RenderTypeHtml("Basic", BuiltInData.BasicMap[type], []);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public async Task HtmlInternalTypes(string type)
    => await RenderTypeHtml("Internal", BuiltInData.InternalMap[type], BuiltIn.Internal);

  private readonly IGqlpSchema _basicSchema = BuiltIn.Basic.Schema();

  [Fact]
  public async Task HtmlAllBasicTypes()
    => await RenderSchemaHtml(_basicSchema, "!Basic");

  private readonly IGqlpSchema _internalSchema = BuiltIn.Internal.Schema();

  [Fact]
  public async Task HtmlAllInternalTypes()
    => await RenderSchemaHtml(_internalSchema, "!Internal", extras: _basicSchema);

  private readonly string[] _sections = ["Basic", "Internal"];

  [Fact]
  public async Task Html_Index()
  {
    Map<IEnumerable<string>> groups = new() {
      ["Basic"] = BuiltIn.Basic.Select(t => t.Name),
      ["Internal"] = BuiltIn.Internal.Select(t => t.Name),
    };

    Structured result = new Map<Structured>() {
      ["title"] = "BuiltIn",
      ["items"] = _sections.Links("!"),
      ["groups"] = groups.Links().Encode(),
    }.Encode("");

    await result.WriteHtmlFileAsync("BuiltIn", "index", "index");
  }

  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public void ModelBasicTypes(string type)
    => ModelType(BuiltInData.BasicMap[type], []);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public void ModelInternalTypes(string type)
    => ModelType(BuiltInData.InternalMap[type], BuiltIn.Internal);

  [Fact]
  public void ModelAllBasicTypes()
  {
    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(_basicSchema, context);

    context.Errors.ShouldBeEmpty();
  }

  [Fact]
  public void ModelAllInternalTypes()
  {
    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(_internalSchema, context, _basicSchema);

    context.Errors.ShouldBeEmpty();
  }

  [Fact]
  public void ModelsFluidFiles()
    => RenderFluid.CheckFluidFiles();

  private void ModelType(IGqlpType type, IGqlpType[] extras)
  {
    Assert.SkipWhen(type is null, "type is null");

    IGqlpSchema schema = type.Schema();

    IGqlpSchema extrasSchema = extras.Where(e => e != type).Schema();

    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(schema, context, extrasSchema);

    context.Errors.ShouldBeEmpty(type?.Label);
  }

  private async Task RenderTypeHtml(string section, IGqlpType type, IGqlpType[] extras)
  {
    Assert.SkipWhen(type is null, "type is null");

    IGqlpSchema schema = type.Schema();

    IGqlpSchema extrasSchema = extras.Where(e => e != type).Schema();

    await RenderSchemaHtml(schema, type.Name, section, extrasSchema);
  }

  private async Task RenderSchemaHtml(IGqlpSchema schema, string filename, string section = "", IGqlpSchema? extras = null)
  {
    Structured result = encoder.EncodeAst(schema, encoder.Context(), extras);

    await result.ThrowIfNull().Add("title", new(filename)).WriteHtmlFileAsync("BuiltIn" + section.Prefixed("/"), filename);
  }
}

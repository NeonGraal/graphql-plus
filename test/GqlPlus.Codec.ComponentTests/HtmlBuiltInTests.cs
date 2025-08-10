using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
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

  private readonly SchemaAst _basicSchema = new(AstNulls.At) { Declarations = BuiltIn.Basic };

  [Fact]
  public async Task HtmlAllBasicTypes()
    => await RenderSchemaHtml(_basicSchema, "!Basic");

  private readonly SchemaAst _internalSchema = new(AstNulls.At) {
    Declarations = BuiltIn.Internal
  };

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

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    SchemaAst extrasSchema = new(AstNulls.At) {
      Declarations = [.. extras.Where(e => e != type)]
    };

    IModelsContext context = encoder.Context();
    Structured result = encoder.EncodeAst(schema, context, extrasSchema);

    context.Errors.ShouldBeEmpty(type?.Label);
  }

  private async Task RenderTypeHtml(string section, IGqlpType type, IGqlpType[] extras)
  {
    Assert.SkipWhen(type is null, "type is null");

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    SchemaAst extrasSchema = new(AstNulls.At) {
      Declarations = [.. extras.Where(e => e != type)]
    };

    await RenderSchemaHtml(schema, type.Name, section, extrasSchema);
  }

  private async Task RenderSchemaHtml(SchemaAst schema, string filename, string section = "", SchemaAst? extras = null)
  {
    Structured result = encoder.EncodeAst(schema, encoder.Context(), extras);

    await result.WriteHtmlFileAsync("BuiltIn" + section.Prefixed("/"), filename);
  }
}

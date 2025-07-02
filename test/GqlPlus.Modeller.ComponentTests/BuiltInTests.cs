using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Convert;
using GqlPlus.Resolving;

namespace GqlPlus;

public class BuiltInTests(IModelAndRender renderer)
{
  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public async Task HtmlBasicTypes(string type)
    => await RenderTypeHtml("Basic", BuiltInData.BasicMap[type], []);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public async Task HtmlInternalTypes(string type)
    => await RenderTypeHtml("Internal", BuiltInData.InternalMap[type], BuiltIn.Internal);

  [Fact]
  public async Task HtmlAllBasicTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Basic
    };

    await RenderSchemaHtml(schema, "!Basic");
  }

  [Fact]
  public async Task HtmlAllInternalTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Internal
    };

    await RenderSchemaHtml(schema, "!Internal");
  }

  private readonly string[] _sections = ["!Basic", "!Internal"];

  [Fact]
  public async Task Html_Index()
  {
    Structured result = new Map<Structured>() {
      ["title"] = "BuiltIn",
      ["items"] = _sections.Render(),
      ["groups"] = new Map<Structured>() {
        ["Basic"] = BuiltIn.Basic.Render(t => t.Name),
        ["Internal"] = BuiltIn.Internal.Render(t => t.Name),
      }.Render(),
    }.Render("");

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
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Basic
    };

    IModelsContext context = renderer.Context();
    Structured result = renderer.RenderAst(schema, context);

    context.Errors.ShouldBeEmpty();
  }

  [Fact]
  public void ModelAllInternalTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Internal
    };

    IModelsContext context = renderer.Context();
    Structured result = renderer.RenderAst(schema, context);

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

    IModelsContext context = renderer.Context();
    Structured result = renderer.RenderAst(schema, context, extrasSchema);

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
    Structured result = renderer.RenderAst(schema, renderer.Context(), extras);

    await result.WriteHtmlFileAsync("BuiltIn" + section.Prefixed("/"), filename);
  }
}

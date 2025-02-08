using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Convert;
using GqlPlus.Resolving;

namespace GqlPlus;

public class BuiltInTests(IModelAndRender renderer)
{
  [SkippableTheory]
  [ClassData(typeof(BuiltInBasicData))]
  public async Task HtmlBasicTypes(string type)
    => await RenderTypeHtml(BuiltInData.BasicMap[type], []);

  [SkippableTheory]
  [ClassData(typeof(BuiltInInternalData))]
  public async Task HtmlInternalTypes(string type)
    => await RenderTypeHtml(BuiltInData.InternalMap[type], BuiltIn.Internal);

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

  [Fact]
  public async Task Html_Index()
  {
    RenderStructure groups = RenderStructure.New("");
    groups.Add("All", RenderStructure.ForAll(["!Basic", "!Internal"]));
    groups.Add("Basic", RenderStructure.ForAll(BuiltIn.Basic.Select(t => t.Name)));
    groups.Add("Internal", RenderStructure.ForAll(BuiltIn.Internal.Select(t => t.Name)));

    RenderStructure result = RenderStructure.New("");
    result.Add("groups", groups);

    await result.WriteHtmlFile("BuiltIn", "index", "index");
  }

  [SkippableTheory]
  [ClassData(typeof(BuiltInBasicData))]
  public void ModelBasicTypes(string type)
    => ModelType(BuiltInData.BasicMap[type], []);

  [SkippableTheory]
  [ClassData(typeof(BuiltInInternalData))]
  public void ModelInternalTypes(string type)
    => ModelType(BuiltInData.InternalMap[type], BuiltIn.Internal);

  [Fact]
  public void ModelAllBasicTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Basic
    };

    ITypesContext context = renderer.Context();
    RenderStructure result = renderer.RenderAst(schema, context);

    context.Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void ModelAllInternalTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Internal
    };

    ITypesContext context = renderer.Context();
    RenderStructure result = renderer.RenderAst(schema, context);

    context.Errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void ModelsFluidFiles()
    => RenderFluid.CheckFluidFiles();

  private void ModelType(IGqlpType type, IGqlpType[] extras)
  {
    Skip.If(type is null);

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    SchemaAst extrasSchema = new(AstNulls.At) {
      Declarations = [.. extras.Where(e => e != type)]
    };

    ITypesContext context = renderer.Context();
    RenderStructure result = renderer.RenderAst(schema, context, extrasSchema);

    context.Errors.Should().BeNullOrEmpty(type?.Label);
  }

  private async Task RenderTypeHtml(IGqlpType type, IGqlpType[] extras)
  {
    Skip.If(type is null);

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    SchemaAst extrasSchema = new(AstNulls.At) {
      Declarations = [.. extras.Where(e => e != type)]
    };

    await RenderSchemaHtml(schema, type.Name, extrasSchema);
  }

  private async Task RenderSchemaHtml(SchemaAst schema, string filename, SchemaAst? extras = null)
  {
    RenderStructure result = renderer.RenderAst(schema, renderer.Context(), extras);

    await result.WriteHtmlFile("BuiltIn", filename);
  }
}

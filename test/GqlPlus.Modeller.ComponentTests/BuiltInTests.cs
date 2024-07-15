using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Convert;

namespace GqlPlus;

public class BuiltInTests(IModelAndRender renderer)
{
  [SkippableTheory]
  [ClassData(typeof(BuiltInBasicData))]
  public void HtmlBasicTypes(string type)
    => RenderTypeHtml(BuiltInData.BasicMap[type], []);

  [SkippableTheory]
  [ClassData(typeof(BuiltInInternalData))]
  public void HtmlInternalTypes(string type)
    => RenderTypeHtml(BuiltInData.InternalMap[type], BuiltIn.Internal);

  [Fact]
  public void HtmlAllBasicTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Basic
    };

    RenderSchemaHtml(schema, "!Basic");
  }

  [Fact]
  public void HtmlAllInternalTypes()
  {
    SchemaAst schema = new(AstNulls.At) {
      Declarations = BuiltIn.Internal
    };

    RenderSchemaHtml(schema, "!Internal");
  }

  [Fact]
  public void Html_Index()
  {
    RenderStructure groups = RenderStructure.New("");
    groups.Add("All", RenderStructure.ForAll(["!Basic", "!Internal"]));
    groups.Add("Basic", RenderStructure.ForAll(BuiltIn.Basic.Select(t => t.Name)));
    groups.Add("Internal", RenderStructure.ForAll(BuiltIn.Internal.Select(t => t.Name)));

    RenderStructure result = RenderStructure.New("");
    result.Add("groups", groups);

    result.WriteHtmlFile("BuiltIn", "index", "index");
  }

  [Fact]
  public void ModelsFluidFiles()
    => RenderFluid.CheckFluidFiles();

  private void RenderTypeHtml(IGqlpType type, IGqlpType[] extras)
  {
    Skip.If(type is null);

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    SchemaAst extrasSchema = new(AstNulls.At) {
      Declarations = [.. extras.Where(e => e != type)]
    };

    RenderSchemaHtml(schema, type.Name, extrasSchema);
  }

  private void RenderSchemaHtml(SchemaAst schema, string filename, SchemaAst? extras = null)
  {
    RenderStructure result = renderer.RenderAst(schema, extras);

    result.WriteHtmlFile("BuiltIn", filename);
  }
}

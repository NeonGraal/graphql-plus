using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Modelling;
using GqlPlus.Modelling.Globals;

namespace GqlPlus;

public class BuiltInTests(
  IModeller<IGqlpSchema, SchemaModel> modeller,
  ITypesModeller types
)
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

  private void RenderTypeHtml(AstType type, AstType[] extras)
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
    TypesCollection context = new(types);
    SchemaModel model = modeller.ToModel(schema, context);
    context.AddModels(model.Types.Values);
    if (extras is not null) {
      SchemaModel extraModel = modeller.ToModel(extras, context);
      context.AddModels(extraModel.Types.Values);
    }

    context.Errors.Clear();

    RenderStructure result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    result.WriteHtmlFile("BuiltIn", filename);
  }
}

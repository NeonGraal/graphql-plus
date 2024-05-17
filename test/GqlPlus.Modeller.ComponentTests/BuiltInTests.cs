using System.Reflection;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Modelling;
using Microsoft.Extensions.FileProviders;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class BuiltInTests(
  IModeller<IGqlpSchema, SchemaModel> modeller,
  ITypesModeller types
)
{
  [SkippableTheory]
  [MethodData("AllBasic", typeof(BuiltIn))]
  public void HtmlBasicTypes(AstType type)
    => RenderTypeHtml(type);

  [SkippableTheory]
  [MethodData("AllInternal", typeof(BuiltIn))]
  public void HtmlInternalTypes(AstType type)
    => RenderTypeHtml(type);

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

  private void RenderTypeHtml(AstType type)
  {
    Skip.If(type is null);

    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    RenderSchemaHtml(schema, type.Name);
  }

  private void RenderSchemaHtml(SchemaAst schema, string filename)
  {
    TypesCollection context = new(types);
    SchemaModel model = modeller.ToModel(schema, context);
    context.AddModels(model.Types.Values);
    context.Errors.Clear();

    RenderStructure result = model.Render(context);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    result.WriteHtmlFile("BuiltIn", filename);
  }

  static BuiltInTests()
    => RenderFluid.Setup(
    new EmbeddedFileProvider(Assembly.GetExecutingAssembly(),
      "GqlPlus.Html"));
}

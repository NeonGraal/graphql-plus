using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;
using GqlPlus.Result;

namespace GqlPlus;

internal sealed class SchemaVerifyChecks(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IModelAndRender schemaRenderer
) : SchemaParseChecks(schemaParser)
  , ISchemaVerifyChecks
{
  public (SchemaModel, IModelsContext) Model_Asts(IEnumerable<IGqlpSchema> asts)
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    IModelsContext context = schemaRenderer.WithBuiltIns();
    context.TypeKinds.Add("_Described", TypeKindModel.Dual);

    SchemaModel model = schemaRenderer.ModelAst(schema, context);

    context.Errors.Add(asts.SelectMany(a => a.Errors));

    return (model, context);
  }

  public Structured Render_Model(SchemaModel model, IModelsContext context)
    => schemaRenderer.RenderModel(model, context);
}

public interface ISchemaVerifyChecks
  : ISchemaParseChecks
{
  (SchemaModel, IModelsContext) Model_Asts(IEnumerable<IGqlpSchema> asts);
  Structured Render_Model(SchemaModel model, IModelsContext context);
}

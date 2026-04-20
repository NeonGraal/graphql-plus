using GqlPlus.Ast.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;

namespace GqlPlus;

internal sealed class SchemaVerifyChecks(
    IParserRepository parsers,
    IMergerRepository mergers,
    IModelAndEncode schemaEncoder
) : SchemaParseChecks(parsers)
  , ISchemaVerifyChecks
{
  private readonly IMerge<IAstSchema> _schemaMerger = mergers.MergerFor<IAstSchema>();

  public (SchemaModel, IModelsContext) Model_Asts(IEnumerable<IAstSchema> asts, bool withBuiltIns, bool addDescribed)
  {
    IAstSchema schema = _schemaMerger.Merge(asts).First();

    IModelsContext context = withBuiltIns ? schemaEncoder.WithBuiltIns() : schemaEncoder.Context();
    if (addDescribed) {
      context.TypeKinds.Add("_Described", TypeKindModel.Dual);
    }

    SchemaModel model = schemaEncoder.ModelAst(schema, context);

    context.Errors.Add(asts.SelectMany(a => a.Errors));

    return (model, context);
  }

  public Structured Encode_Model(SchemaModel model, IModelsContext context)
    => schemaEncoder.EncodeModel(model, context);
}

public interface ISchemaVerifyChecks
  : ISchemaParseChecks
{
  (SchemaModel, IModelsContext) Model_Asts(IEnumerable<IAstSchema> asts, bool withBuiltIns, bool addDescribed);
  Structured Encode_Model(SchemaModel model, IModelsContext context);
}

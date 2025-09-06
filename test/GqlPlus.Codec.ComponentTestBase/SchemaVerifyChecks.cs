using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Resolving;

namespace GqlPlus;

internal sealed class SchemaVerifyChecks(
    Parser<IGqlpSchema>.D schemaParser,
    IMerge<IGqlpSchema> schemaMerger,
    IModelAndEncode schemaEncoder
) : SchemaParseChecks(schemaParser)
  , ISchemaVerifyChecks
{
  public (SchemaModel, IModelsContext) Model_Asts(IEnumerable<IGqlpSchema> asts, bool withBuiltIns = true)
  {
    IGqlpSchema schema = schemaMerger.Merge(asts).First();

    IModelsContext context = withBuiltIns ? schemaEncoder.WithBuiltIns() : schemaEncoder.Context();
    context.TypeKinds.Add("_Described", TypeKindModel.Dual);

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
  (SchemaModel, IModelsContext) Model_Asts(IEnumerable<IGqlpSchema> asts, bool withBuiltIns = true);
  Structured Encode_Model(SchemaModel model, IModelsContext context);
}

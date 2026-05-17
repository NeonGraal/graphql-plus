using GqlPlus.Ast.Schema;
using GqlPlus.Merging;
using GqlPlus.Modelling;
using GqlPlus.Parsing;
using GqlPlus.Resolving;
using GqlPlus.Schema;

namespace GqlPlus;

public interface ISchGraphQlPlusVerifyChecks
  : ISchemaParseChecks
{
  (ISch_SchemaObject adapted, IModelsContext context) Adapt_Asts(
    IEnumerable<IAstSchema> asts, bool withBuiltIns, bool addDescribed);
  Structured Encode_Schema(ISch_SchemaObject schema);
}

#pragma warning disable CA1812 // Instantiated via Dependency Injection
internal sealed class SchGraphQlPlusVerifyChecks(
  IParserRepository parsers,
  IMergerRepository mergers,
  IModelAndEncode modelAndEncode,
  IEncoderRepository encoders,
  IModeller<IAstSchema, ISch_SchemaObject> schemaModeller
) : SchemaParseChecks(parsers)
  , ISchGraphQlPlusVerifyChecks
{
  private readonly MergerOne<IAstSchema> _schemaMerger = mergers.MergerFor<IAstSchema>();

  public (ISch_SchemaObject, IModelsContext) Adapt_Asts(
    IEnumerable<IAstSchema> asts, bool withBuiltIns, bool addDescribed)
  {
    IAstSchema schema = _schemaMerger.Merge(asts).First();

    IModelsContext context = withBuiltIns ? modelAndEncode.WithBuiltIns() : modelAndEncode.Context();
    if (addDescribed) {
      context.TypeKinds.Add("_Described", TypeKindModel.Dual);
    }

    ISch_SchemaObject schemaObject = schemaModeller.ToModel(schema, context.TypeKinds);

    context.Errors.Add(asts.SelectMany(a => a.Errors));

    return (schemaObject, context);
  }

  public Structured Encode_Schema(ISch_SchemaObject schema)
  {
    Encoder<ISch_SchemaObject> encoder = encoders.EncoderFor<ISch_SchemaObject>();
    return encoder.Encode(schema);
  }
}
#pragma warning restore CA1812

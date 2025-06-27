using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;
using GqlPlus.Resolving;

namespace GqlPlus;

#pragma warning disable CA1812 // Instantiated via Dependency Injection
internal sealed class ModelAndEncode(
  IModeller<IGqlpSchema, SchemaModel> modeller,
  IResolver<SchemaModel> resolver,
  IEncoder<SchemaModel> encoder,
  ITypesModeller types
) : IModelAndEncode
{
  public IModelsContext Context() => new TypesContext(types);

  public Structured EncodeAst(IGqlpSchema schema, IModelsContext context, IGqlpSchema? extras = null)
  {
    types.AddTypeKinds(schema.Declarations.ArrayOf<IGqlpType>(), context.TypeKinds);
    if (extras is not null) {
      SchemaModel extraModel = modeller.ToModel(extras, context.TypeKinds);
      context.AddModels(extraModel.Types.Values);
    }

    SchemaModel model = modeller.ToModel(schema, context.TypeKinds);
    context.AddModels(model.Types.Values);

    context.Errors.Clear();
    model = resolver.Resolve(model, context);

    Structured result = encoder.Encode(model);
    if (context.Errors.Count > 0) {
      string key = result.Map.ContainsKey(new("_errors")) ? "_ctxErrors" : "errors";
      result.Add(key, context.Errors.Encode());
    }

    return result;
  }

  public IModelsContext WithBuiltIns() => TypesContext.WithBuiltins(types);
}
#pragma warning restore CA1812

public interface IModelAndEncode
{
  IModelsContext Context();
  IModelsContext WithBuiltIns();
  Structured EncodeAst(IGqlpSchema schema, IModelsContext context, IGqlpSchema? extras = null);
}

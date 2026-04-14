using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;
using GqlPlus.Resolving;

namespace GqlPlus;

#pragma warning disable CA1812 // Instantiated via Dependency Injection
internal sealed class ModelAndEncode(
  IModellerRepository modellers,
  IResolverRepository resolvers,
  IEncoderRepository encoders
) : IModelAndEncode
{
  public IModelsContext Context() => new TypesContext(modellers.TypesModeller);

  public Structured EncodeAst(IAstSchema schema, IModelsContext context, IAstSchema? extras = null)
    => EncodeModel(ModelAst(schema, context, extras), context);

  public SchemaModel ModelAst(IAstSchema schema, IModelsContext context, IAstSchema? extras = null)
  {
    modellers.TypesModeller.AddTypeKinds(schema.Declarations.ArrayOf<IAstType>(), context.TypeKinds);
    if (extras is not null) {
      SchemaModel extraModel = modellers.ModellerFor<IAstSchema, SchemaModel>().ToModel(extras, context.TypeKinds);
      context.AddModels(extraModel.Types.Values);
    }

    SchemaModel model = modellers.ModellerFor<IAstSchema, SchemaModel>().ToModel(schema, context.TypeKinds);
    context.AddModels(model.Types.Values);

    return resolvers.ResolverFor<SchemaModel>().Resolve(model, context);
  }

  public Structured EncodeModel(SchemaModel model, IModelsContext? context)
  {
    Structured result = encoders.EncoderFor<SchemaModel>().Encode(model);
    if (context?.Errors.Count > 0) {
      string key = result.Map.ContainsKey(new("_errors")) ? "_ctxErrors" : "errors";
      result.Add(key, context.Errors.Encode());
    }

    return result;
  }

  public IModelsContext WithBuiltIns() => TypesContext.WithBuiltins(modellers.TypesModeller);
}
#pragma warning restore CA1812

public interface IModelAndEncode
{
  IModelsContext Context();
  IModelsContext WithBuiltIns();
  Structured EncodeAst(IAstSchema schema, IModelsContext context, IAstSchema? extras = null);
  SchemaModel ModelAst(IAstSchema schema, IModelsContext context, IAstSchema? extras = null);
  Structured EncodeModel(SchemaModel model, IModelsContext context);
}

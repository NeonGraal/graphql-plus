using GqlPlus.Ast.Schema;
using GqlPlus.Encoding;
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
  private readonly DeferOne<ITypesModeller> _types = modellers.TypesModeller();
  private readonly Modeller<IAstSchema, SchemaModel> _schema = modellers.ModellerFor<IAstSchema, SchemaModel>();
  private readonly Resolver<SchemaModel> _resolver = resolvers.ResolverFor<SchemaModel>();

  public IModelsContext Context() => new TypesContext(_types.I);

  public Structured EncodeAst(IAstSchema schema, IModelsContext context, IAstSchema? extras = null)
    => EncodeModel(ModelAst(schema, context, extras), context);

  public SchemaModel ModelAst(IAstSchema schema, IModelsContext context, IAstSchema? extras = null)
  {
    _types.I.AddTypeKinds(schema.Declarations.ArrayOf<IAstType>(), context.TypeKinds);
    if (extras is not null) {
      SchemaModel extraModel = _schema.ToModel(extras, context.TypeKinds);
      context.AddModels(extraModel.Types.Values);
    }

    SchemaModel model = _schema.ToModel(schema, context.TypeKinds);
    context.AddModels(model.Types.Values);

    return _resolver.Resolve(model, context);
  }

  public Structured EncodeModel(SchemaModel model, IModelsContext? context)
  {
    Encoder<SchemaModel> encoder = encoders.EncoderFor<SchemaModel>();
    Structured result = encoder.Encode(model);
    if (context?.Errors.Count > 0) {
      string key = result.Map.ContainsKey(new("_errors")) ? "_ctxErrors" : "errors";
      result.Add(key, context.Errors.Encode());
    }

    return result;
  }

  public IModelsContext WithBuiltIns() => TypesContext.WithBuiltins(_types.I);
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

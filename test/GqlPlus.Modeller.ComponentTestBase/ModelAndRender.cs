using GqlPlus.Abstractions.Schema;
using GqlPlus.Modelling;
using GqlPlus.Resolving;

namespace GqlPlus;

#pragma warning disable CA1812 // Instantiated via Dependency Injection
internal sealed class ModelAndRender(
  IModeller<IGqlpSchema, SchemaModel> modeller,
  IResolver<SchemaModel> resolver,
  IRenderer<SchemaModel> renderer,
  ITypesModeller types
) : IModelAndRender
{
  public IModelsContext Context() => new TypesContext(types);

  public Structured RenderAst(IGqlpSchema schema, IModelsContext context, IGqlpSchema? extras = null)
    => RenderModel(ModelAst(schema, context, extras), context);

  public SchemaModel ModelAst(IGqlpSchema schema, IModelsContext context, IGqlpSchema? extras = null)
  {
    types.AddTypeKinds(schema.Declarations.ArrayOf<IGqlpType>(), context.TypeKinds);
    if (extras is not null) {
      SchemaModel extraModel = modeller.ToModel(extras, context.TypeKinds);
      context.AddModels(extraModel.Types.Values);
    }

    SchemaModel model = modeller.ToModel(schema, context.TypeKinds);
    context.AddModels(model.Types.Values);

    context.Errors.Clear();
    return resolver.Resolve(model, context);
  }

  public Structured RenderModel(SchemaModel model, IModelsContext? context)
  {
    Structured result = renderer.Render(model);
    if (context?.Errors.Count > 0) {
      string key = result.Map.ContainsKey(new("_errors")) ? "_ctxErrors" : "errors";
      result.Add(key, context.Errors.Render());
    }

    return result;
  }

  public IModelsContext WithBuiltIns() => TypesContext.WithBuiltins(types);
}
#pragma warning restore CA1812

public interface IModelAndRender
{
  IModelsContext Context();
  IModelsContext WithBuiltIns();
  Structured RenderAst(IGqlpSchema schema, IModelsContext context, IGqlpSchema? extras = null);
  SchemaModel ModelAst(IGqlpSchema schema, IModelsContext context, IGqlpSchema? extras = null);
  Structured RenderModel(SchemaModel model, IModelsContext context);
}

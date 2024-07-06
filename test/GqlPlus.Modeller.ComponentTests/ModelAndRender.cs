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
  public RenderStructure RenderAst(IGqlpSchema schema, IGqlpSchema? extras = null, bool withBuiltIns = false)
  {
    TypesCollection context = withBuiltIns
      ? TypesCollection.WithBuiltins(types)
      : new(types);

    SchemaModel model = modeller.ToModel(schema, context);
    context.AddModels(model.Types.Values);
    if (extras is not null) {
      SchemaModel extraModel = modeller.ToModel(extras, context);
      context.AddModels(extraModel.Types.Values);
    }

    context.Errors.Clear();
    model = resolver.Resolve(model, context);

    RenderStructure result = renderer.Render(model);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
    }

    return result;
  }
}
#pragma warning restore CA1812

public interface IModelAndRender
{
  RenderStructure RenderAst(IGqlpSchema schema, IGqlpSchema? extras = null, bool withBuiltIns = false);
}

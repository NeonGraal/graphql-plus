﻿using GqlPlus.Abstractions.Schema;
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
  {
    SchemaModel model = modeller.ToModel(schema, context.TypeKinds);
    context.AddModels(model.Types.Values);
    if (extras is not null) {
      SchemaModel extraModel = modeller.ToModel(extras, context.TypeKinds);
      context.AddModels(extraModel.Types.Values);
    }

    context.Errors.Clear();
    model = resolver.Resolve(model, context);

    Structured result = renderer.Render(model);
    if (context.Errors.Count > 0) {
      result.Add("_errors", context.Errors.Render());
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
}

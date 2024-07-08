namespace GqlPlus.Resolving;

internal abstract class ResolverChildType<TModel, TParent>
  : IResolver<TModel>
  where TModel : ChildTypeModel<TParent>
  where TParent : IModelBase
{
  public virtual TModel Resolve(TModel model, IResolveContext context)
  {
    if (model.Parent is not null) {
      ResolveParent(model, context);
    }

    return model;
  }

  protected virtual void ResolveParent(TModel model, IResolveContext context)
  {
    if (model.ParentModel is null) {
      if (context.TryGetType(model.Name, ParentName(model), out TModel? parentModel)) {
        model.ParentModel = Resolve(parentModel, context);
      }
    }
  }

  protected abstract string? ParentName(TModel model);
}

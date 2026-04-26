namespace GqlPlus.Resolving.Simple;

internal abstract class ResolverParentType<TModel, TItem, TAll>
  : ResolverChildType<TModel, TypeRefModel<SimpleKindModel>>
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  protected override string? ParentName(TModel model)
    => model.Parent?.Name;

  public override TModel Resolve(TModel model, IResolveContext context)
  {
    model = base.Resolve(model, context);

    IEnumerable<TAll> allItems = model.Items.Select(i => NewItem(model, i));

    if (model.ParentModel is TModel parent) {
      model.AllItems = [.. parent.AllItems, .. allItems];
    } else {
      model.AllItems = [.. allItems];
    }

    return model;
  }

  protected abstract TAll NewItem(TModel model, TItem item);
}

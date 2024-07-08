
namespace GqlPlus.Resolving;

internal abstract class ResolverParentType<TModel, TItem, TAll>
  : ResolverChildType<TModel, TypeRefModel<SimpleKindModel>>
  , ITypeResolver
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  public bool ForType(BaseTypeModel model)
    => model is TModel;

  public BaseTypeModel ResolveType(BaseTypeModel model, IResolveContext context)
    => Resolve((TModel)model, context);

  protected override string? ParentName(TModel model)
    => model.Parent?.Name;
  public override TModel Resolve(TModel model, IResolveContext context)
  {
    model = base.Resolve(model, context);

    var allItems = model.Items.Select(i => NewItem(model, i));

    if (model.ParentModel is TModel parent) {
      model.AllItems = [.. parent.AllItems, .. allItems];
    } else {
      model.AllItems = [.. allItems];
    }

    return model;
  }

  protected abstract TAll NewItem(TModel model, TItem item);
}

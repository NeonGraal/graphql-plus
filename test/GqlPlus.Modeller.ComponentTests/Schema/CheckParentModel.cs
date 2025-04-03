using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Schema;

internal abstract class CheckParentModel<TAst, TTypeKind, TModel, TItem>(
  CheckTypeInputs<TAst, TModel> inputs,
  TTypeKind kind
) : CheckTypeModel<TAst, TTypeKind, TModel>(inputs, kind)
  , IParentModel<TItem>
  , ICheckTypeModel<TTypeKind, TModel>
  where TAst : IGqlpType<string>
  where TModel : IModelBase
{
  BaseTypeModel IParentModel<TItem>.NewParent(string name, TItem[] items, string? parent)
    => NewParent(name, items, parent);

  public IEnumerable<string> ExpectedItems(string field, string[] items)
    => ItemsExpected(field, items, ExpectedItem);

  private IEnumerable<string> ExpectedItem(string item)
        => ["- !_Aliased", "  name: " + item];

  public IEnumerable<string> ExpectedAllItems(string field, string[] items, string type)
    => ItemsExpected(field, items, ExpectedAllItem(type));

  internal abstract BaseTypeModel NewParent(string name, TItem[] items, string? parent = null);

  protected abstract ToExpected<string> ExpectedAllItem(string type);
}

public interface ICheckParentModel<TTypeKind, TRender>
  : ICheckTypeModel<TTypeKind, TRender>
  where TRender : IModelBase
{
  IEnumerable<string> ExpectedItems(string field, string[] items);
  IEnumerable<string> ExpectedAllItems(string field, string[] items, string type);
}

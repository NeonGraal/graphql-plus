using GqlPlus.Abstractions.Schema;
using GqlPlus.Resolving;

namespace GqlPlus.Modelling;

internal abstract class CheckParentModel<TAst, TTypeKind, TModel, TItem>(
  CheckTypeInputs<TAst, TModel> inputs,
  TTypeKind kind
) : CheckTypeModel<TAst, TTypeKind, TModel>(inputs, kind)
  , IParentModel<TItem>
  , ICheckTypeModel<TTypeKind, TModel>
  where TAst : IGqlpType<string>
  where TModel : IModelBase
{
  BaseTypeModel IParentModel<TItem>.NewParent(string name, TItem[] members, string? parent)
    => NewParent(name, members, parent);

  public IEnumerable<string> ExpectedMembers(string field, string[] members)
    => ItemsExpected(field, members, ExpectedMember);

  private IEnumerable<string> ExpectedMember(string member)
        => ["- !_Aliased", "  name: " + member];

  public IEnumerable<string> ExpectedAllMembers(string field, string[] members, string type)
    => ItemsExpected(field, members, ExpectedAllMember(type));

  internal abstract BaseTypeModel NewParent(string name, TItem[] members, string? parent = null);

  protected abstract ToExpected<string> ExpectedAllMember(string type);
}

public interface ICheckParentModel<TTypeKind, TRender>
  : ICheckTypeModel<TTypeKind, TRender>
  where TRender : IModelBase
{
  IEnumerable<string> ExpectedMembers(string field, string[] members);
  IEnumerable<string> ExpectedAllMembers(string field, string[] members, string type);
}

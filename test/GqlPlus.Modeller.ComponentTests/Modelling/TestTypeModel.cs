using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling;

public abstract class TestTypeModel<TAstParent, TParent, TTypeKind>
  : TestAliasedModel<string>
  where TAstParent : IEquatable<TAstParent>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, TParent parent)
    => TypeChecks.TypeExpected(
      TypeChecks.TypeAst(name, parent),
      TypeChecks.ExpectedType(new(name, parent)));

  internal override ICheckAliasedModel<string> AliasedChecks => TypeChecks;

  internal abstract ICheckTypeModel<TAstParent, TParent, TTypeKind> TypeChecks { get; }
}

public abstract class TestTypeModel<TTypeKind>
  : TestTypeModel<string, string, TTypeKind>
{ }

internal abstract class CheckTypeModel<TAstParent, TParent, TAst, TTypeKind, TModel>
  : CheckAliasedModel<string, TAst, TModel>
  , ICheckTypeModel<TAstParent, TParent, TTypeKind>
  where TAstParent : IEquatable<TAstParent>
  where TAst : IGqlpType<TAstParent>
  where TModel : IRendering
{
  protected readonly TTypeKind TypeKind;
  protected readonly string TypeKindLower;

  TTypeKind ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeKind => TypeKind;
  string ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeKindLower => TypeKindLower;

  protected CheckTypeModel(IModeller<TAst, TModel> modeller, IRenderer<TModel> rendering, TTypeKind kind)
    : base(modeller, rendering)
    => (TypeKind, TypeKindLower) = (kind, $"{kind}".ToLowerInvariant());

  protected abstract string[] ExpectedType(ExpectedTypeInput<TParent> input);

  protected abstract string[] ExpectedParent(TParent? parent);

  internal abstract TAst NewTypeAst(string name, TAstParent? parent = default, string? description = null, string[]? aliases = null);

  internal abstract TAstParent NewParentAst(TParent input);

  string[] ICheckTypeModel<TAstParent, TParent, TTypeKind>.ExpectedType(ExpectedTypeInput<TParent> input)
    => ExpectedType(input);

  TAstParent ICheckTypeModel<TAstParent, TParent, TTypeKind>.ParentAst(TParent parent)
    => NewParentAst(parent);
  IGqlpType<TAstParent> ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeAst(string name, TParent parent)
    => NewTypeAst(name, NewParentAst(parent), "");

  void ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeExpected(IGqlpType<TAstParent> type, string[] expected)
    => AstExpected((TAst)type, expected);

  protected override TAst NewAliasedAst(string input, string? description = null, string[]? aliases = null)
    => NewTypeAst(input, default, description, aliases);
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedType(new(input));
}

internal abstract class CheckTypeModel<TAst, TTypeKind, TModel>(
  IModeller<TAst, TModel> modeller,
  IRenderer<TModel> rendering,
  TTypeKind kind
) : CheckTypeModel<string, string, TAst, TTypeKind, TModel>(modeller, rendering, kind)
  , ICheckTypeModel<TTypeKind>
  where TAst : IGqlpType<string>
  where TModel : IRendering
{
  internal override string NewParentAst(string input)
    => input;
}

internal abstract class CheckTypeModel<TAst, TTypeKind, TModel, TItem>(
  IModeller<TAst, TModel> modeller,
  IRenderer<TModel> rendering,
  TTypeKind kind
) : CheckTypeModel<TAst, TTypeKind, TModel>(modeller, rendering, kind)
  , IParentModel<TItem>
  where TAst : IGqlpType<string>
  where TModel : IRendering
{
  internal abstract BaseTypeModel NewParent(string name, TItem[] members, string? parent = null);

  BaseTypeModel IParentModel<TItem>.NewParent(string name, TItem[] members, string? parent)
    => NewParent(name, members, parent);

  internal IEnumerable<string> ExpectedMembers(string field, string[] members)
    => ItemsExpected(field, members, ExpectedMember);

  private IEnumerable<string> ExpectedMember(string member)
        => ["- !_Aliased", "  name: " + member];

  internal IEnumerable<string> ExpectedAllMembers(string field, string[] members, string type)
    => ItemsExpected(field, members, ExpectedAllMember(type));

  protected abstract ToExpected<string> ExpectedAllMember(string type);
}

internal interface ICheckTypeModel<TAstParent, TParent, TTypeKind>
  : ICheckAliasedModel<string>
  where TAstParent : IEquatable<TAstParent>
{
  TTypeKind TypeKind { get; }
  string TypeKindLower { get; }
  void TypeExpected(IGqlpType<TAstParent> type, string[] expected);
  IGqlpType<TAstParent> TypeAst(string name, TParent parent);
  TAstParent ParentAst(TParent parent);
  string[] ExpectedType(ExpectedTypeInput<TParent> input);
}

internal interface ICheckTypeModel<TTypeKind>
  : ICheckTypeModel<string, string, TTypeKind>
{ }

internal interface IParentModel<TItem>
{
  BaseTypeModel NewParent(string name, TItem[] members, string? parent = null);
}

internal class ExpectedTypeInput<TParent>(
  string name,
  TParent? parent = default,
  IEnumerable<string>? aliases = null,
  string? description = null)
  : ExpectedDescriptionAliasesInput<string>(name, aliases, description)
{
  internal TParent? Parent { get; } = parent;

  internal ExpectedTypeInput(ExpectedDescriptionAliasesInput<string> input)
    : this(input.Name)
  {
    Aliases = input.Aliases;
    Description = input.Description;
  }
}

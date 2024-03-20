using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

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
  where TAst : AstType<TAstParent>
  where TModel : IRendering
{
  protected readonly TTypeKind TypeKind;
  protected readonly string TypeKindLower;

  TTypeKind ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeKind => TypeKind;
  string ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeKindLower => TypeKindLower;

  protected CheckTypeModel(IModeller<TAst, TModel> modeller, TTypeKind kind)
    : base(modeller)
    => (TypeKind, TypeKindLower) = (kind, $"{kind}".ToLowerInvariant());

  protected abstract string[] ExpectedType(ExpectedTypeInput<TParent> input);

  protected abstract string[] ExpectedParent(TParent? parent);

  internal abstract TAst NewTypeAst(string name, TAstParent? parent, string description);

  internal abstract TAstParent NewReferenceAst(TParent input);

  string[] ICheckTypeModel<TAstParent, TParent, TTypeKind>.ExpectedType(ExpectedTypeInput<TParent> input)
    => ExpectedType(input);

  TAstParent ICheckTypeModel<TAstParent, TParent, TTypeKind>.ParentAst(TParent parent)
    => NewReferenceAst(parent);
  AstType<TAstParent> ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeAst(string name, TParent parent)
    => NewTypeAst(name, NewReferenceAst(parent), "");

  void ICheckTypeModel<TAstParent, TParent, TTypeKind>.TypeExpected(AstType<TAstParent> type, string[] expected)
    => AstExpected((TAst)type, expected);

  protected override TAst NewDescribedAst(string input, string description)
    => NewTypeAst(input, default, description);
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedType(new(input));
}

internal abstract class CheckTypeModel<TAst, TTypeKind, TModel>(
  IModeller<TAst, TModel> modeller,
  TTypeKind kind
) : CheckTypeModel<string, string, TAst, TTypeKind, TModel>(modeller, kind)
  , ICheckTypeModel<TTypeKind>
  where TAst : AstType<string>
  where TModel : IRendering
{
  internal override string NewReferenceAst(string input)
    => input;
}

internal abstract class CheckTypeModel<TAst, TTypeKind, TModel, TItem>(
  IModeller<TAst, TModel> modeller,
  TTypeKind kind
) : CheckTypeModel<TAst, TTypeKind, TModel>(modeller, kind)
  , ICheckTypeModel<TTypeKind, TItem>
  where TAst : AstType<string>
  where TModel : IRendering
{
  internal abstract BaseTypeModel NewParent(string name, TItem[] members, string? parent = null);
  BaseTypeModel ICheckTypeModel<TTypeKind, TItem>.NewParent(string name, TItem[] members, string? parent)
    => NewParent(name, members, parent);
}

internal interface ICheckTypeModel<TAstParent, TParent, TTypeKind>
  : ICheckAliasedModel<string>
  where TAstParent : IEquatable<TAstParent>
{
  TTypeKind TypeKind { get; }
  string TypeKindLower { get; }
  void TypeExpected(AstType<TAstParent> type, string[] expected);
  AstType<TAstParent> TypeAst(string name, TParent parent);
  TAstParent ParentAst(TParent parent);
  string[] ExpectedType(ExpectedTypeInput<TParent> input);
}

internal interface ICheckTypeModel<TTypeKind>
  : ICheckTypeModel<string, string, TTypeKind>
{ }

internal interface ICheckTypeModel<TTypeKind, TItem>
  : ICheckTypeModel<string, string, TTypeKind>
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

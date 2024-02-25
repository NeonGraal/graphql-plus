using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TypeModelTests<TAstParent, TParent, TTypeKind>
  : AliasedModelTests<string>
  where TAstParent : IEquatable<TAstParent>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, TParent parent)
    => TypeChecks.TypeExpected(
      TypeChecks.TypeAst(name, parent),
      TypeChecks.ExpectedType(name, parent));

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => TypeChecks.ExpectedType(input, default, [aliases], [description]);

  internal override IAliasedModelChecks<string> AliasedChecks => TypeChecks;

  internal abstract ITypeModelChecks<TAstParent, TParent, TTypeKind> TypeChecks { get; }
}

public abstract class TypeModelTests<TTypeKind>
  : TypeModelTests<string, string, TTypeKind>
{ }

internal abstract class TypeModelChecks<TAstParent, TParent, TAst, TTypeKind>
  : AliasedModelChecks<string, TAst>, ITypeModelChecks<TAstParent, TParent, TTypeKind>
  where TAstParent : IEquatable<TAstParent>
  where TAst : AstType<TAstParent>
{
  protected readonly TTypeKind TypeKind;
  protected readonly IModeller<AstType<TAstParent>> Type;

  TTypeKind ITypeModelChecks<TAstParent, TParent, TTypeKind>.TypeKind => TypeKind;

  protected TypeModelChecks(TTypeKind kind, IModeller<AstType<TAstParent>> type)
    => (TypeKind, Type) = (kind, type);

  protected virtual string[] ExpectedType(
    string name,
    TParent? parent,
    IEnumerable<string>? aliases = null,
    IEnumerable<string>? description = null
  ) => [$"!_{TypeKind}",
        .. aliases ?? [],
        .. description ?? [],
        $"kind: !_TypeKind {TypeKind}",
        "name: " + name,
        .. ExpectedParent(parent)];

  protected abstract string[] ExpectedParent(TParent? parent);

  internal abstract TAst NewTypeAst(string name, TAstParent? parent, string description);

  internal abstract TAstParent NewParentAst(TParent input);

  string[] ITypeModelChecks<TAstParent, TParent, TTypeKind>.ExpectedType(
    string name,
    TParent? parent,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description
  ) => ExpectedType(name, parent, aliases, description);

  TAstParent ITypeModelChecks<TAstParent, TParent, TTypeKind>.ParentAst(TParent parent)
    => NewParentAst(parent);
  AstType<TAstParent> ITypeModelChecks<TAstParent, TParent, TTypeKind>.TypeAst(string name, TParent parent)
    => NewTypeAst(name, NewParentAst(parent), "");

  void ITypeModelChecks<TAstParent, TParent, TTypeKind>.TypeExpected(AstType<TAstParent> type, string[] expected)
    => AstExpected((TAst)type, expected);

  protected override IRendering AstToModel(TAst aliased)
    => Type.ToRenderer(aliased);

  protected override TAst NewDescribedAst(string input, string description)
    => NewTypeAst(input, default, description);
}

internal abstract class TypeModelChecks<TAst, TTypeKind>(
  TTypeKind kind,
  IModeller<AstType<string>> type
) : TypeModelChecks<string, string, TAst, TTypeKind>(kind, type), ITypeModelChecks<TTypeKind>
  where TAst : AstType<string>
{
  internal override string NewParentAst(string input)
    => input;
}

internal interface ITypeModelChecks<TAstParent, TParent, TTypeKind>
  : IAliasedModelChecks<string>
  where TAstParent : IEquatable<TAstParent>
{
  TTypeKind TypeKind { get; }
  void TypeExpected(AstType<TAstParent> type, string[] expected);
  AstType<TAstParent> TypeAst(string name, TParent parent);
  TAstParent ParentAst(TParent parent);
  string[] ExpectedType(string name, TParent? parent, IEnumerable<string>? aliases = null, IEnumerable<string>? description = null);
}

internal interface ITypeModelChecks<TTypeKind>
  : ITypeModelChecks<string, string, TTypeKind>
{ }

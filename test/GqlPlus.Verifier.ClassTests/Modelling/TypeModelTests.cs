using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TypeModelTests<TParent>
  : AliasedModelTests<string>
  where TParent : IEquatable<TParent>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, TParent parent)
    => TypeChecks.TypeExpected(
      TypeChecks.TypeAst(name, parent),
      TypeChecks.ExpectedType(name, parent));

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => TypeChecks.ExpectedType(input, default, [aliases], [description]);

  internal override IAliasedModelChecks<string> AliasedChecks => TypeChecks;

  internal abstract ITypeModelChecks<TParent> TypeChecks { get; }
}

internal abstract class TypeModelChecks<TParent, TAst, TTypeKind>
  : AliasedModelChecks<string, TAst>, ITypeModelChecks<TParent>
  where TParent : IEquatable<TParent>
  where TAst : AstType<TParent>
{
  protected readonly TTypeKind TypeKind;
  protected readonly IModeller<AstType<TParent>> Type;

  protected TypeModelChecks(TTypeKind kind, IModeller<AstType<TParent>> type)
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
        .. TypeParent(parent)];

  internal abstract TAst NewTypeAst(string name, TParent? parent, string description);

  protected abstract string[] TypeParent(TParent? parent);

  string[] ITypeModelChecks<TParent>.ExpectedType(
    string name,
    TParent? parent,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description
  ) => ExpectedType(name, parent, aliases, description);

  AstType<TParent> ITypeModelChecks<TParent>.TypeAst(string name, TParent parent)
    => NewTypeAst(name, parent, "");

  void ITypeModelChecks<TParent>.TypeExpected(AstType<TParent> type, string[] expected)
    => AstExpected((TAst)type, expected);

  protected override IRendering AstToModel(TAst aliased)
    => Type.ToRenderer(aliased);

  protected override TAst NewDescribedAst(string input, string description)
    => NewTypeAst(input, default, description);
}

internal interface ITypeModelChecks<TParent>
  : IAliasedModelChecks<string>
  where TParent : IEquatable<TParent>
{
  void TypeExpected(AstType<TParent> type, string[] expected);
  AstType<TParent> TypeAst(string name, TParent parent);
  string[] ExpectedType(string name, TParent? parent, IEnumerable<string>? aliases = null, IEnumerable<string>? description = null);
}

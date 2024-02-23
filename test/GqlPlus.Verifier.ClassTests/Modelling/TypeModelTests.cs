using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TypeModelTests<TAstParent, TParent>
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

  internal abstract ITypeModelChecks<TAstParent, TParent> TypeChecks { get; }
}

public abstract class TypeModelTests
  : TypeModelTests<string, string>
{ }

internal abstract class TypeModelChecks<TAstParent, TParent, TAst, TTypeKind>
  : AliasedModelChecks<string, TAst>, ITypeModelChecks<TAstParent, TParent>
  where TAstParent : IEquatable<TAstParent>
  where TAst : AstType<TAstParent>
{
  protected readonly TTypeKind TypeKind;
  protected readonly IModeller<AstType<TAstParent>> Type;

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

  string[] ITypeModelChecks<TAstParent, TParent>.ExpectedType(
    string name,
    TParent? parent,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description
  ) => ExpectedType(name, parent, aliases, description);

  AstType<TAstParent> ITypeModelChecks<TAstParent, TParent>.TypeAst(string name, TParent parent)
    => NewTypeAst(name, NewParentAst(parent), "");

  void ITypeModelChecks<TAstParent, TParent>.TypeExpected(AstType<TAstParent> type, string[] expected)
    => AstExpected((TAst)type, expected);

  protected override IRendering AstToModel(TAst aliased)
    => Type.ToRenderer(aliased);

  protected override TAst NewDescribedAst(string input, string description)
    => NewTypeAst(input, default, description);
}

internal abstract class TypeModelChecks<TAst, TTypeKind>
  : TypeModelChecks<string, string, TAst, TTypeKind>, ITypeModelChecks
  where TAst : AstType<string>
{
  protected TypeModelChecks(TTypeKind kind, IModeller<AstType<string>> type)
    : base(kind, type)
  { }

  internal override string NewParentAst(string input)
    => input;
}

internal interface ITypeModelChecks<TAstParent, TParent>
  : IAliasedModelChecks<string>
  where TAstParent : IEquatable<TAstParent>
{
  void TypeExpected(AstType<TAstParent> type, string[] expected);
  AstType<TAstParent> TypeAst(string name, TParent parent);
  string[] ExpectedType(string name, TParent? parent, IEnumerable<string>? aliases = null, IEnumerable<string>? description = null);
}

internal interface ITypeModelChecks
  : ITypeModelChecks<string, string>
{ }

using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class UnionDeclAst(
  ITokenAt At,
  string Name,
  string Description,
  IAstUnionMember[] Items
) : AstSimple<IAstUnionMember>(At, Name, Description, Items)
  , IAstUnion
{
  public override TypeKind Kind => TypeKind.Union;

  public UnionDeclAst(TokenAt at, string name, UnionMemberAst[] members)
    : this(at, name, "", members) { }

  public bool HasValue(string value)
    => Items.Select(a => a.Name).Contains(value);

  public bool Equals(UnionDeclAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}

using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class UnionDeclAst(
  TokenAt At,
  string Name,
  string Description,
  IGqlpUnionMember[] Members
) : AstSimple<IGqlpUnionMember>(At, Name, Description, Members)
  , IGqlpUnion
{
  internal override string Abbr => "Un";
  public override string Label => "Union";

  public UnionDeclAst(TokenAt at, string name, UnionMemberAst[] members)
    : this(at, name, "", members) { }

  public bool HasValue(string value)
    => Items.Select(a => a.Name).Contains(value);

  public bool Equals(UnionDeclAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}

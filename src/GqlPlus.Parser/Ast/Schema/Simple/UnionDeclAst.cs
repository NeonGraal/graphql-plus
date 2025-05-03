using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class UnionDeclAst(
  ITokenAt At,
  string Name,
  string Description,
  UnionMemberAst[] Members
) : AstSimple<UnionMemberAst>(At, Name, Description, Members)
  , IEquatable<UnionDeclAst>
  , IGqlpUnion
{
  internal override string Abbr => "Un";
  public override string Label => "Union";

  IEnumerable<IGqlpUnionMember> IGqlpSimple<IGqlpUnionMember>.Items => Items;

  public UnionDeclAst(TokenAt at, string name, UnionMemberAst[] members)
    : this(at, name, "", members) { }

  public bool HasValue(string value)
    => Items.Select(a => a.Name).Contains(value);

  public bool Equals(UnionDeclAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}

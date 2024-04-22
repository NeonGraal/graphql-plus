using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Simple;

public sealed record class UnionDeclAst(
  TokenAt At,
  string Name,
  string Description,
  UnionMemberAst[] Members
) : AstSimple(At, Name, Description), IEquatable<UnionDeclAst>
{
  internal override string Abbr => "U";
  public override string Label => "Union";

  public UnionDeclAst(TokenAt at, string name, UnionMemberAst[] members)
    : this(at, name, "", members) { }

  public bool Equals(UnionDeclAst? other)
    => base.Equals(other)
      && Members.SequenceEqual(other.Members);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Members.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Parent.Prefixed(":"))
      .Concat(Members.Bracket());

  internal bool HasValue(string value)
    => Members.Select(a => a.Name).Contains(value);
}

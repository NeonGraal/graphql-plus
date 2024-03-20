using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class UnionDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstType<string>(At, Name, Description), IEquatable<UnionDeclAst>
{
  public string[] Members { get; set; } = [];

  internal override string Abbr => "U";
  public override string Label => "Union";

  public UnionDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

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
    => Members.Contains(value);
}

using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstType<string>(At, Name, Description), IEquatable<EnumDeclAst>
{
  public EnumMemberAst[] Members { get; set; } = [];

  internal override string Abbr => "E";
  public override string Label => "Enum";

  public EnumDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(EnumDeclAst? other)
    => base.Equals(other)
      && Members.SequenceEqual(other.Members);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Members.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Parent.Prefixed(":"))
      .Concat(Members.Bracket());

  internal bool HasValue(string value)
    => Members.Any(v => v.Name == value || v.Aliases.Contains(value));
}

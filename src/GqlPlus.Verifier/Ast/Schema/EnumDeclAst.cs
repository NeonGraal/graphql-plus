using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description), IEquatable<EnumDeclAst>
{
  public string? Extends { get; set; }
  public EnumMemberAst[] Members { get; set; } = [];

  internal override string Abbr => "E";
  public override string Label => "Enum";

  public EnumDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(EnumDeclAst? other)
    => base.Equals(other)
      && Extends.NullEqual(other.Extends)
      && Members.SequenceEqual(other.Members);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Extends, Members.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Extends.Prefixed(":"))
      .Concat(Members.Bracket());

  internal bool HasValue(string value)
    => Members.Any(v => v.Name == value || v.Aliases.Contains(value));
}

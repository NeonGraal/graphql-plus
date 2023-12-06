using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description), IEquatable<EnumDeclAst>
{
  public string? Extends { get; set; }
  public EnumLabelAst[] Labels { get; set; } = Array.Empty<EnumLabelAst>();

  internal override string Abbr => "E";

  public EnumDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(EnumDeclAst? other)
    => base.Equals(other)
      && Extends.NullEqual(other.Extends)
      && Labels.SequenceEqual(other.Labels);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Extends, Labels.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Extends.Prefixed(":"))
      .Concat(Labels.Bracket());
}

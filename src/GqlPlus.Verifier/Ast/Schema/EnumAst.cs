namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class EnumAst(TokenAt At, string Name, string Description)
  : AstType(At, Name, Description), IEquatable<EnumAst>
{
  public string? Extends { get; set; }
  public EnumLabelAst[] Labels { get; set; } = Array.Empty<EnumLabelAst>();

  internal override string Abbr => "E";

  public EnumAst(TokenAt at, string name)
    : this(at, name, "") { }

  public bool Equals(EnumAst? other)
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

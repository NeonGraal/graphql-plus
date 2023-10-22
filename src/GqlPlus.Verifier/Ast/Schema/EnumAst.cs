namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class EnumAst(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<EnumAst>
{
  public string? Extends { get; set; }
  public EnumLabelAst[] Labels { get; set; } = Array.Empty<EnumLabelAst>();

  internal override string Abbr => "E";

  public EnumAst(ParseAt at, string name)
    : this(at, name, "") { }

  public bool Equals(EnumAst? other)
    => base.Equals(other)
      && Extends.NullEqual(other.Extends)
      && Labels.OrderedEqual(other.Labels);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Extends, Labels.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Extends.Prefixed(":"))
      .Concat(Labels.Bracket());
}

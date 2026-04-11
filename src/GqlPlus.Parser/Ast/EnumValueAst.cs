namespace GqlPlus.Ast;

internal sealed record class EnumValueAst(
  ITokenAt At,
  string Label
) : AstAbbreviated(At)
  , IAstEnumValue
{
  public string Type { get; } = "";

  public string EnumValue
    => Type.Suffixed(".") + Label;

  internal override string Abbr => "e";

  string IAstEnumValue.EnumType => Type;
  string IAstEnumValue.EnumLabel => Label;

  internal EnumValueAst(
    ITokenAt at,
    string enumType,
    string enumLabel
  )
    : this(at, enumLabel)
    => Type = enumType;

  public bool Equals(EnumValueAst? other)
    => other is IAstEnumValue enumValue && Equals(enumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Label);

  public bool Equals(IAstEnumValue? other)
    => base.Equals(other)
      && Type.NullEqual(other.EnumType)
      && Label.Equals(other.EnumLabel, StringComparison.Ordinal);
  public int CompareTo(IAstEnumValue? other)
    => EnumValue.Compare(other?.EnumValue);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(EnumValue);
}

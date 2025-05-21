using System.Globalization;
using GqlPlus.Token;

namespace GqlPlus.Ast;

internal sealed record class FieldKeyAst(
  ITokenAt At
) : AstAbbreviated(At)
  , IGqlpFieldKey
{
  public string? Type { get; }
  public string? Label { get; }

  public decimal? Number { get; }
  public string? Text { get; }
  public string? EnumValue
    => Type.Suffixed(".") + Label;

  internal override string Abbr => "k";

  string? IGqlpFieldKey.EnumType => Type;
  string? IGqlpFieldKey.EnumLabel => Label;

  internal FieldKeyAst(TokenAt at, decimal number)
    : this(at)
    => Number = number;
  internal FieldKeyAst(TokenAt at, string content)
    : this(at)
    => Text = content;
  internal FieldKeyAst(TokenAt at, string enumType, string enumLabel)
    : this(at)
    => (Type, Label) = (enumType, enumLabel);

  public bool Equals(FieldKeyAst? other)
    => other is IGqlpFieldKey fieldKey && Equals(fieldKey);
  public override int GetHashCode()
  => HashCode.Combine(base.GetHashCode(), Type, Label, Number, Text);

  public bool Equals(IGqlpFieldKey? other)
    => CompareTo(other) == 0;
  public int CompareTo(IGqlpFieldKey? other)
    => Number is not null ? decimal.Compare(Number.Value, other?.Number ?? 0)
      : Text is not null ? string.Compare(Text, other?.Text, StringComparison.Ordinal)
      : EnumValue is not null ? string.Compare(EnumValue, other?.EnumValue, StringComparison.Ordinal)
      : -1;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Number?.ToString(CultureInfo.InvariantCulture))
      .Append(EnumValue?.ToString())
      .Append(Text is not null ? $"'{Text}'" : null);
}

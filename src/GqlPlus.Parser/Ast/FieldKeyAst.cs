using System.Globalization;
using GqlPlus.Token;

namespace GqlPlus.Ast;

internal sealed record class FieldKeyAst(
  ITokenAt At
) : AstAbbreviated(At)
  , IGqlpFieldKey
{
  public decimal? Number { get; }
  public string? Text { get; }
  public IGqlpEnumValue? EnumValue { get; }

  // Backward compatibility properties
  public string? EnumLabel => EnumValue?.EnumLabel;
  public string? EnumType => EnumValue?.EnumType;

  internal override string Abbr => "k";

  internal FieldKeyAst(TokenAt at, decimal number)
    : this(at)
    => Number = number;
  internal FieldKeyAst(TokenAt at, string content)
    : this(at)
    => Text = content;
  internal FieldKeyAst(TokenAt at, string enumType, string enumLabel)
    : this(at)
    => EnumValue = new EnumValueAst(at, enumType, enumLabel);
  internal FieldKeyAst(IGqlpEnumValue enumValue)
    : this(enumValue.At)
    => EnumValue = enumValue;

  public bool Equals(FieldKeyAst? other)
    => other is IGqlpFieldKey fieldKey && Equals(fieldKey);
  public override int GetHashCode()
  => HashCode.Combine(base.GetHashCode(), EnumValue, Number, Text);

  public bool Equals(IGqlpFieldKey? other)
    => CompareTo(other) == 0;
  public int CompareTo(IGqlpFieldKey? other)
    => this switch {
      { EnumValue: not null }
        => EnumValue.CompareTo(other?.EnumValue),
      { Number: not null }
        => decimal.Compare(Number.Value, other?.Number ?? 0),
      { Text: not null } when !string.IsNullOrEmpty(Text)
        => string.Compare(Text, other?.Text, StringComparison.Ordinal),
      _ => -1
    };

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(this switch {
        { Number: not null }
          => Number?.ToString(CultureInfo.InvariantCulture),
        { EnumValue: not null } when !string.IsNullOrWhiteSpace(EnumValue.EnumValue)
          => EnumValue.EnumValue,
        { Text: not null }
          => $"'{Text}'",
        _ => null
      });
}

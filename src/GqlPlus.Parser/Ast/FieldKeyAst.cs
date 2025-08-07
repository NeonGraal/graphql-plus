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
    => this switch {
      { Number: not null } => decimal.Compare(Number.Value, other?.Number ?? 0),
      { EnumValue: not null } when !string.IsNullOrWhiteSpace(EnumValue)
        => string.Compare(EnumValue, other?.EnumValue, StringComparison.Ordinal),
      { Text: not null } when !string.IsNullOrEmpty(Text)
        => string.Compare(Text, other?.Text, StringComparison.Ordinal),
      _ => -1
    };

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(this switch {
        { Number: not null }
          => Number?.ToString(CultureInfo.InvariantCulture),
        { EnumValue: not null } when !string.IsNullOrWhiteSpace(EnumValue)
          => EnumValue,
        { Text: not null }
          => $"'{Text}'",
        _ => null
      });
}

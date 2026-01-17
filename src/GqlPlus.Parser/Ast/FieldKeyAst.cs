using System.Globalization;
using GqlPlus.Token;

namespace GqlPlus.Ast;

internal sealed record class FieldKeyAst(
  ITokenAt At
) : AstAbbreviated(At)
  , IGqlpFieldKey
{
  public decimal? Number { get; }
  public string? Text { get; internal init; }
  public IGqlpEnumValue? EnumValue { get; }

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
  => HashCode.Combine(base.GetHashCode(), EnumValue.NullHashCode(), Number, Text);

  public bool Equals(IGqlpFieldKey? other)
    => CompareTo(other) == 0;
  public int CompareTo(IGqlpFieldKey? other)
    => Apply(
      e => e.CompareTo(other?.EnumValue),
      n => decimal.Compare(n, other?.Number ?? 0),
      t => t.Compare(other?.Text),
      -1);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Apply(
        e => e.EnumValue,
        n => n.ToString(CultureInfo.InvariantCulture),
        t => $"'{t}'",
        null));

  private T Apply<T>(
    Func<IGqlpEnumValue, T> enumFunc,
    Func<decimal, T> numberFunc,
    Func<string, T> textFunc,
    T empty)
    => this switch {
      { EnumValue: not null } when !string.IsNullOrWhiteSpace(EnumValue.EnumValue) => enumFunc(EnumValue),
      { Number: not null } => numberFunc(Number.Value),
      { Text: not null } when !string.IsNullOrEmpty(Text) => textFunc(Text),
      _ => empty
    };
}

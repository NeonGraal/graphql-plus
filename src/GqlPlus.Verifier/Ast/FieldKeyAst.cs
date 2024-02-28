using System.Globalization;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

[SuppressMessage("Design", "CA1036:Override methods on comparable types")]
public record class FieldKeyAst(TokenAt At)
  : AstAbbreviated(At), IComparable<FieldKeyAst>
{
  internal string? Type { get; }
  internal string? Value { get; }

  public decimal? Number { get; }
  public string? Text { get; }
  public string? EnumValue
    => Type.Suffixed(".") + Value;

  internal override string Abbr => "k";

  internal FieldKeyAst(TokenAt at, decimal number)
    : this(at)
    => Number = number;
  internal FieldKeyAst(TokenAt at, string content)
    : this(at)
    => Text = content;
  internal FieldKeyAst(TokenAt at, string enumType, string enumValue)
    : this(at)
    => (Type, Value) = (enumType, enumValue);

  public int CompareTo(FieldKeyAst? other)
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

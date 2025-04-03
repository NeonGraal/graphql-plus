using System.Globalization;

using GqlPlus.Token;

namespace GqlPlus.Ast;

internal sealed record class FieldKeyAst(TokenAt At)
  : AstAbbreviated(At)
  , IComparable<FieldKeyAst>
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
  bool IEquatable<IGqlpFieldKey>.Equals(IGqlpFieldKey? other)
    => Equals(other as FieldKeyAst);
  int IComparable<IGqlpFieldKey>.CompareTo(IGqlpFieldKey? other)
    => CompareTo(other as FieldKeyAst);

  internal FieldKeyAst(TokenAt at, decimal number)
    : this(at)
    => Number = number;
  internal FieldKeyAst(TokenAt at, string content)
    : this(at)
    => Text = content;
  internal FieldKeyAst(TokenAt at, string enumType, string enumLabel)
    : this(at)
    => (Type, Label) = (enumType, enumLabel);

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

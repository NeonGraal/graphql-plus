using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

public record class FieldKeyAst(TokenAt At)
  : AstBase(At), IComparable<FieldKeyAst>
{
  internal string? Type { get; }
  internal string? Value { get; }

  public decimal? Number { get; }
  public string? String { get; }
  public string? EnumValue
    => Type.Suffixed(".") + Value;

  internal override string Abbr => "k";

  internal FieldKeyAst(TokenAt at, decimal number)
    : this(at)
    => Number = number;
  internal FieldKeyAst(TokenAt at, string content)
    : this(at)
    => String = content;
  internal FieldKeyAst(TokenAt at, string enumType, string enumValue)
    : this(at)
    => (Type, Value) = (enumType, enumValue);

  public int CompareTo(FieldKeyAst? other)
    => Number is not null ? Number?.CompareTo(other?.Number) ?? -1
      : String is not null ? string.Compare(String, other?.String, StringComparison.Ordinal)
      : EnumValue is not null ? string.Compare(EnumValue, other?.EnumValue, StringComparison.Ordinal)
      : -1;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Number?.ToString())
      .Append(EnumValue?.ToString())
      .Append(String is not null ? $"'{String}'" : null);
}

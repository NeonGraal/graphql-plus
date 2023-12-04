﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

public record class FieldKeyAst(TokenAt At)
  : AstBase(At), IComparable<FieldKeyAst>
{
  internal string? Type { get; }
  internal string? Label { get; }

  public decimal? Number { get; }
  public string? String { get; }
  public string? EnumLabel
    => Type.Suffixed(".") + Label;

  internal override string Abbr => "k";

  internal FieldKeyAst(TokenAt at, decimal number)
    : this(at)
    => Number = number;
  internal FieldKeyAst(TokenAt at, string content)
    : this(at)
    => String = content;
  internal FieldKeyAst(TokenAt at, string theType, string label)
    : this(at)
    => (Type, Label) = (theType, label);

  public int CompareTo(FieldKeyAst? other)
    => Number is not null ? Number?.CompareTo(other?.Number) ?? -1
      : String is not null ? string.Compare(String, other?.String, StringComparison.Ordinal)
      : EnumLabel is not null ? string.Compare(EnumLabel, other?.EnumLabel, StringComparison.Ordinal)
      : -1;

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Number?.ToString())
      .Append(EnumLabel?.ToString())
      .Append(String is not null ? $"'{String}'" : null);
}

﻿namespace GqlPlus.Verifier.Ast;

internal record class FieldKeyAst : AstBase, IComparable<FieldKeyAst>
{
  internal string? Type { get; }
  internal string? Label { get; }

  public decimal? Number { get; }
  public string? String { get; }
  public string? EnumLabel
    => Type.Suffixed(".") + Label;

  protected override string Abbr => "K";

  internal FieldKeyAst() { }
  internal FieldKeyAst(decimal number)
    => Number = number;
  internal FieldKeyAst(string content)
    => String = content;
  internal FieldKeyAst(string theType, string label)
    => (Type, Label) = (theType, label);

  public int CompareTo(FieldKeyAst? other)
    => Number is not null ? Number?.CompareTo(other?.Number) ?? -1
      : String is not null ? String.CompareTo(other?.String)
      : EnumLabel is not null ? EnumLabel.CompareTo(other?.EnumLabel)
      : -1;

  internal override IEnumerable<string?> GetFields()
    => String is not null ? new[] { $"'{String}'" }
      : Number is not null ? new[] { $"{Number}" }
      : EnumLabel is not null ? new[] { $"{EnumLabel}" }
      : base.GetFields();
}

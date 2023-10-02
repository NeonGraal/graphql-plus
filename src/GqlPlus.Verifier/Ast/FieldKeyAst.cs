namespace GqlPlus.Verifier.Ast;

internal record class FieldKeyAst : AstBase, IComparable<FieldKeyAst>
{
  internal string? Type { get; set; }

  internal string? Label { get; set; }

  internal decimal? Number { get; set; }

  internal string? String { get; set; }

  internal FieldKeyAst() { }
  internal FieldKeyAst(decimal number)
    => Number = number;
  internal FieldKeyAst(string content)
    => String = content;
  internal FieldKeyAst(string theType, string label)
    => (Type, Label) = (theType, label);

  public int CompareTo(FieldKeyAst? other)
    => Number is not null ? Number?.CompareTo(other?.Number) ?? -1
      : String is not null ? string.CompareOrdinal(String, other?.String)
      : Label is not null ? string.CompareOrdinal(Type + '.' + Label, other?.Type + '.' + other?.Label)
      : -1;

  internal override IEnumerable<string?> GetFields()
    => String is not null ? new[] { $"'{String}'" }
      : Number is not null ? new[] { $"{Number}" }
      : Type is { Length: > 0 } ? new[] { $"{Type}.{Label}" }
      : Label is not null ? new[] { $"{Label}" }
      : base.GetFields();
}

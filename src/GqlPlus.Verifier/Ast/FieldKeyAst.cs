namespace GqlPlus.Verifier.Ast;

internal record class FieldKeyAst : AstBase, IComparable<FieldKeyAst>
{
  internal string? Type { get; }
  internal string? Label { get; }

  public decimal? Number { get; }
  public string? String { get; }
  public string? EnumLabel
    => Type.Suffixed(".") + Label;

  protected override string Abbr => "K";

  internal FieldKeyAst(ParseAt at)
    : base(at) { }
  internal FieldKeyAst(ParseAt at, decimal number)
    : base(at)
    => Number = number;
  internal FieldKeyAst(ParseAt at, string content)
    : base(at)
    => String = content;
  internal FieldKeyAst(ParseAt at, string theType, string label)
    : base(at)
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

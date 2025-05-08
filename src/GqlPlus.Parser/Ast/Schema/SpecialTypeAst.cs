using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

internal sealed record class SpecialTypeAst
  : AstType
  , IGqlpTypeSpecial
{
  internal override string Abbr => "TZ";
  public override string Label { get; }
  public string? Parent => null;

  public SpecialTypeAst(string label)
    : base(AstNulls.At, "_" + label, "")
    => Label = label;

  public bool Equals(SpecialTypeAst? other)
    => other is IGqlpType<string> parented && Equals(parented);
  public bool Equals(IGqlpType<string>? other)
    => base.Equals(other)
    && Label == other.Label;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Label);
}

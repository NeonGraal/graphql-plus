using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Ast.Schema;

internal sealed record class SpecialTypeAst
  : AstSimple
  , IGqlpTypeSpecial
{
  internal override string Abbr => "TZ";
  public override string Label { get; }
  public new string? Parent => null;

  public SpecialTypeAst(string label)
    : base(AstNulls.At, "_" + label, "")
    => Label = label;

  public bool Equals(SpecialTypeAst? other)
    => other is IGqlpType<string> parented && Equals(parented);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Label);
}

using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;
internal record class SpecialTypeAst
  : AstType, IGqlpTypeSpecial
{
  internal override string Abbr => "TZ";
  public override string Label { get; }
  public string? Parent => null;

  public SpecialTypeAst(string label)
    : base(AstNulls.At, "_" + label, "")
    => Label = label;
}

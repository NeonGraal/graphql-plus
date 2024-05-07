using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;
public record class SpecialTypeAst : AstType
{
  internal override string Abbr => "TZ";
  public override string Label { get; }

  public SpecialTypeAst(TokenAt at, string label)
    : base(at, "_" + label, "")
    => Label = label;
}

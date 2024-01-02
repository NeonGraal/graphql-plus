using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;
public record class SpecialTypeAst : AstType
{
  internal override string Abbr => "Z";
  public override string Label { get; }

  public SpecialTypeAst(TokenAt at, string label)
    : base(at, "_" + label, "")
    => Label = label;
}

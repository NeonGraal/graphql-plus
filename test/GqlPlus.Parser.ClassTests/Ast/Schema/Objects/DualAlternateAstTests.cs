using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualAlternateAstTests
  : AstObjectAlternateTests<DualAlternateAst, IGqlpDualBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !DA {input.Type} )";

  private readonly AstObjectAlternateChecks<DualAlternateAst, IGqlpDualBase, DualBaseAst> _checks
    = new((dual, objBase) => new(AstNulls.At, objBase),
      dual => new DualBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.DualBases());

  internal override IAstObjectAlternateChecks<DualAlternateAst, IGqlpDualBase> AlternateChecks => _checks;
}

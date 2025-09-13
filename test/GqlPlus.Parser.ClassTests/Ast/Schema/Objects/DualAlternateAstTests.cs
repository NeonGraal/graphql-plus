using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualAlternateAstTests
  : AstObjectAlternateTests<IGqlpDualBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !DA {input.Type} )";

  private readonly AstObjectAlternateChecks<DualAlternateAst, IGqlpDualBase, DualBaseAst, IGqlpObjArg, DualArgAst> _checks
    = new(dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.DualArgs());

  internal override IAstObjectAlternateChecks<IGqlpDualBase> AlternateChecks => _checks;
}

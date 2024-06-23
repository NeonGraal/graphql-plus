using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputAlternateAstTests
  : AstObjectAlternateTests<InputAlternateAst, IGqlpInputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !IA {input.Type} )";

  private readonly AstObjectAlternateChecks<InputAlternateAst, IGqlpInputBase, InputBaseAst> _checks
    = new((dual, objBase) => new(AstNulls.At, objBase),
      dual => new InputBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.InputBases());

  internal override IAstObjectAlternateChecks<InputAlternateAst, IGqlpInputBase> AlternateChecks => _checks;
}

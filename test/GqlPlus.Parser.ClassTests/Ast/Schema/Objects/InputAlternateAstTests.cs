using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputAlternateAstTests
  : AstObjectAlternateTests<IGqlpInputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !IA {input.Type} )";

  internal override IAstObjectAlternateChecks<IGqlpInputBase> AlternateChecks
    => new AstObjectAlternateChecks<InputAlternateAst, IGqlpInputBase, InputBaseAst, InputArgAst>(
      dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.InputArgs());
}

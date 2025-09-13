using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputAlternateAstTests
  : AstObjectAlternateTests<IGqlpInputBase>
{
  [Theory, RepeatData]
  public void String_ForDual(AlternateInput input, string[] arguments)
    => AlternateChecks.String_ForDual(input, arguments);

  protected override string AbbreviatedString(AlternateInput input)
    => $"( !IA {input.Type} )";

  internal override IAstObjectAlternateChecks<IGqlpInputBase> AlternateChecks
    => new AstObjectAlternateChecks<InputAlternateAst, IGqlpInputBase, InputBaseAst, IGqlpObjArg, InputArgAst>(
      dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.InputArgs());
}

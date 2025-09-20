namespace GqlPlus.Ast.Schema.Objects;

public class InputAlternateAstTests
  : AstObjectAlternateTests
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !IA {input.Type} )";

  internal override IAstObjectAlternateChecks AlternateChecks
    => new AstObjectAlternateChecks<InputAlternateAst, InputBaseAst, InputArgAst>(
      dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.InputArgs());
}

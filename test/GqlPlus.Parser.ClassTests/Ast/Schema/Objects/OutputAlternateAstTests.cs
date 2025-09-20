namespace GqlPlus.Ast.Schema.Objects;

public class OutputAlternateAstTests
  : AstObjectAlternateTests
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !OA {input.Type} )";

  internal override IAstObjectAlternateChecks AlternateChecks
    => new AstObjectAlternateChecks<OutputAlternateAst, OutputBaseAst, OutputArgAst>(
      dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.OutputArgs());
}

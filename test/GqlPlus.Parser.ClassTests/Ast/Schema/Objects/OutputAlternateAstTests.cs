using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputAlternateAstTests
  : AstObjectAlternateTests<IGqlpOutputBase>
{
  [Theory, RepeatData]
  public void String_ForDual(AlternateInput input, string[] arguments)
    => AlternateChecks.String_ForDual(input, arguments);

  protected override string AbbreviatedString(AlternateInput input)
    => $"( !OA {input.Type} )";

  internal override IAstObjectAlternateChecks<IGqlpOutputBase> AlternateChecks
    => new AstObjectAlternateChecks<OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst>(
      dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.OutputArgs());
}

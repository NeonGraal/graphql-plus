using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputAlternateAstTests
  : AstObjectAlternateTests<IGqlpOutputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !OA {input.Type} )";

  internal override IAstObjectAlternateChecks<IGqlpOutputBase> AlternateChecks
    => new AstObjectAlternateChecks<OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, OutputArgAst>(
      dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.OutputArgs());
}

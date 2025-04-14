using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputAlternateAstTests
  : AstObjectAlternateTests<IGqlpOutputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !OA {input.Type} )";

  private readonly AstObjectAlternateChecks<OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst> _checks
    = new(dual => new(AstNulls.At, dual.Type, ""),
      arguments => arguments.OutputArgs());

  internal override IAstObjectAlternateChecks<IGqlpOutputBase> AlternateChecks => _checks;
}

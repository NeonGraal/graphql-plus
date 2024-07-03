using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputAlternateAstTests
  : AstObjectAlternateTests<IGqlpOutputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !OA {input.Type} )";

  private readonly AstObjectAlternateChecks<OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArgument, OutputArgumentAst> _checks
    = new((dual, objBase) => new(AstNulls.At, objBase),
      dual => new OutputBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.OutputArguments());

  internal override IAstObjectAlternateChecks<IGqlpOutputBase> AlternateChecks => _checks;
}

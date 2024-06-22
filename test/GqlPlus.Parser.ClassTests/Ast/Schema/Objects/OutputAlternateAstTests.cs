using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputAlternateAstTests
  : AstObjectAlternateTests<OutputAlternateAst, IGqlpOutputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !OA {input.Type} )";

  private readonly AstObjectAlternateChecks<OutputAlternateAst, IGqlpOutputBase, OutputBaseAst> _checks
    = new((dual, objBase) => new(AstNulls.At, objBase),
      dual => new OutputBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.OutputBases());


  internal override IAstObjectAlternateChecks<OutputAlternateAst, IGqlpOutputBase> AlternateChecks => _checks;
}

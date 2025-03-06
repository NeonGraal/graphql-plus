using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class OutputAlternateAstTests
  : AstObjectAlternateTests<IGqlpOutputBase>
{
  protected override string AbbreviatedString(AlternateInput input)
    => $"( !OA {input.Type} )";

  private readonly AstObjectAlternateChecks<OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst> _checks
    = new((dual, objBase) => new(AstNulls.At, objBase),
      dual => new OutputBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.OutputArgs());

  internal override IAstObjectAlternateChecks<IGqlpOutputBase> AlternateChecks => _checks;
}

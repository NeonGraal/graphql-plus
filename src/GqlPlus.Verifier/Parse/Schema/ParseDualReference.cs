using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseDualReference
  : ObjectReferenceParser<DualReferenceAst>
{
  protected override DualReferenceAst Reference(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<DualReferenceAst> TypeEnumValue<TContext>(TContext tokens, DualReferenceAst reference)
    => reference.Ok();
}

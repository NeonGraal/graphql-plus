using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseDualReference
  : ObjectReferenceParser<DualReferenceAst>
{
  protected override DualReferenceAst Reference(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<DualReferenceAst> TypeEnumValue<TContext>(TContext tokens, DualReferenceAst reference)
    => reference.Ok();
}

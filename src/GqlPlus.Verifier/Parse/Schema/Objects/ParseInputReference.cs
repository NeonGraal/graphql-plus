using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseInputReference
  : ObjectReferenceParser<InputReferenceAst>
{
  protected override InputReferenceAst Reference(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<InputReferenceAst> TypeEnumValue<TContext>(TContext tokens, InputReferenceAst reference)
    => reference.Ok();
}

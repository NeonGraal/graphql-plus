using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseInputReference : ObjectReferenceParser<InputReferenceAst>
{
  protected override InputReferenceAst Reference(TokenAt at, string param)
    => new(at, param);

  protected override IResult<InputReferenceAst> TypeEnumValue<TContext>(TContext tokens, InputReferenceAst reference)
    => reference.Ok();
}

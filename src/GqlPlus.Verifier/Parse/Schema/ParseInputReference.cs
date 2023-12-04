using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseInputReference : ObjectReferenceParser<InputReferenceAst>
{
  protected override InputReferenceAst Reference(TokenAt at, string param)
    => new(at, param);

  protected override IResult<InputReferenceAst> TypeEnumLabel<TContext>(TContext tokens, InputReferenceAst reference)
    => reference.Ok();
}

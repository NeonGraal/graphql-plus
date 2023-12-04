using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutputReference : ObjectReferenceParser<OutputReferenceAst>
{
  protected override OutputReferenceAst Reference(TokenAt at, string param)
    => new(at, param);

  protected override IResult<OutputReferenceAst> TypeEnumLabel<TContext>(TContext tokens, OutputReferenceAst reference)
  {
    if (tokens.Take('.')) {
      if (tokens.Identifier(out var label)) {
        reference.Label = label;
        return reference.Ok();
      }

      return tokens.Error("Output", "label after '.'", reference);
    }

    return reference.Ok();
  }
}

using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOutputReference : ObjectReferenceParser<OutputReferenceAst>
{
  protected override OutputReferenceAst Reference(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<OutputReferenceAst> TypeEnumValue<TContext>(TContext tokens, OutputReferenceAst reference)
  {
    if (tokens.Take('.')) {
      if (tokens.Identifier(out var enumValue)) {
        reference.EnumValue = enumValue;
        return reference.Ok();
      }

      return tokens.Error("Output", "enum value after '.'", reference);
    }

    return reference.Ok();
  }
}

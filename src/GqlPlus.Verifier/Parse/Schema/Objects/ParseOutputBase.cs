using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal class ParseOutputBase
  : ObjectBaseParser<OutputBaseAst>
{
  protected override OutputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<OutputBaseAst> TypeEnumValue<TContext>(TContext tokens, OutputBaseAst objBase)
  {
    if (tokens.Take('.')) {
      if (tokens.Identifier(out var enumValue)) {
        objBase.EnumValue = enumValue;
        return objBase.Ok();
      }

      return tokens.Error("Output", "enum value after '.'", objBase);
    }

    return objBase.Ok();
  }
}

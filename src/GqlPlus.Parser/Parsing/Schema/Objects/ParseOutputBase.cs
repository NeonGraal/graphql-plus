using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputBase(
  Parser<IGqlpOutputArg>.DA parseArgs
) : ObjectBaseParser<IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst>(parseArgs)
{
  protected override OutputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<OutputBaseAst> TypeEnumValue<TContext>(TContext tokens, OutputBaseAst objBase)
  {
    if (tokens.Take('.')) {
      if (tokens.Identifier(out string? enumMember)) {
        objBase.EnumMember = enumMember;
        return objBase.Ok();
      }

      return tokens.Error("Output", "enum value after '.'", objBase);
    }

    return objBase.Ok();
  }
}

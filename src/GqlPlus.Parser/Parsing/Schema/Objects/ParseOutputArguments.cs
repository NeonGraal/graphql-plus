using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputArgs
  : ObjectArgsParser<IGqlpOutputArg, OutputArgAst>
{
  protected override OutputArgAst ObjType(TokenAt at, string type, string description)
    => new(at, type, description);
  protected override IResult<OutputArgAst> ArgEnumValue<TContext>(TContext tokens, OutputArgAst argument)
  {
    if (tokens.Take('.')) {
      if (argument.IsTypeParam) {
        tokens.Error("Invalid Output Arg. Enum value not allowed after Type parameter.");
      }

      TokenAt at = tokens.At;
      if (tokens.Identifier(out string? enumMember)) {
        argument = argument with { EnumMember = enumMember };
        return argument.Ok<OutputArgAst>();
      }

      return tokens.Error<OutputArgAst>("Output Arg", "enum value after '.'", argument);
    }

    return argument.Ok();
  }
}

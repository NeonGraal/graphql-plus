using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputArguments
  : ObjectArgumentsParser<IGqlpOutputArgument, OutputArgumentAst>
{
  protected override OutputArgumentAst ObjType(TokenAt at, string type, string description)
    => new(at, type, description);
  protected override IResult<OutputArgumentAst> ArgumentEnumValue<TContext>(TContext tokens, OutputArgumentAst argument)
  {
    if (tokens.Take('.')) {
      if (argument.IsTypeParameter) {
        tokens.Error("Invalid Output Argument. Enum value not allowed after Type parameter.");
      }

      TokenAt at = tokens.At;
      if (tokens.Identifier(out string? enumMember)) {
        argument = argument with { EnumMember = enumMember };
        return argument.Ok<OutputArgumentAst>();
      }

      return tokens.Error<OutputArgumentAst>("Output Argument", "enum value after '.'", argument);
    }

    return argument.Ok();
  }
}

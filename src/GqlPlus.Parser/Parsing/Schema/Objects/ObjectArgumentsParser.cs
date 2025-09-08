using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectArgumentsParser<TObjArg, TObjArgAst>
  : Parser<TObjArg>.IA
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  public IResultArray<TObjArg> Parse(ITokenizer tokens, string label)
  {
    List<TObjArg> list = [];

    if (!tokens.Take('<')) {
      return list.EmptyArray();
    }

    IResult<TObjArgAst> argument = ParseObjectArg(tokens, label);
    while (argument.Required(list.Add)) {
      argument = ParseObjectArg(tokens, label);
    }

    if (argument.IsError()) {
      return argument.AsResultArray(list);
    } else if (!tokens.Take('>')) {
      return tokens.ErrorArray(label, "'>' after type argument(s)", list);
    } else if (list.Count < 1) {
      return tokens.ErrorArray(label, "at least one type argument after '<'", list);
    }

    return list.OkArray();
  }

  private IResult<TObjArgAst> ParseObjectArg(ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<TObjArgAst>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      TObjArgAst objType = ObjArgument(at, param!, description) with {
        IsTypeParam = true,
      };
      return objType.Ok();
    }

    at = tokens.At;

    bool hasName = tokens.Identifier(out string? name);
    if (!hasName) {
      if (hasName = tokens.TakeZero()) {
        name = "0";
      } else if (hasName = tokens.TakeAny(out char simple, '^', '*', '_')) {
        name = $"{simple}";
      }
    }

    if (!hasName) {
      return 0.Empty<TObjArgAst>();
    }

    TObjArgAst argument = ObjArgument(at, name!, description);

    if (tokens.Take('.')) {
      if (argument.IsTypeParam) {
        return tokens.Error<TObjArgAst>("Output Arg", "Enum value not allowed after Type parameter");
      }

      at = tokens.At;
      if (tokens.Identifier(out string? enumLabel)) {
        argument = argument with { EnumLabel = enumLabel };
        return argument.Ok();
      }

      return tokens.Error("Output Arg", "enum value after '.'", argument);
    }

    return argument.Ok();
  }

  protected abstract TObjArgAst ObjArgument(TokenAt at, string type, string description);
}

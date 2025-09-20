using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseObjArgs
  : Parser<IGqlpObjArg>.IA
{
  public IResultArray<IGqlpObjArg> Parse(ITokenizer tokens, string label)
  {
    List<IGqlpObjArg> list = [];

    if (!tokens.Take('<')) {
      return list.EmptyArray();
    }

    IResult<ObjArgAst> argument = ParseObjectArg(tokens, label);
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

  private static IResult<ObjArgAst> ParseObjectArg(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<ObjArgAst>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      ObjArgAst objType = new(at, param!, description) {
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
      return 0.Empty<ObjArgAst>();
    }

    ObjArgAst argument = new(at, name!, description);

    if (tokens.Take('.')) {
      if (argument.IsTypeParam) {
        return tokens.Error<ObjArgAst>("Output Arg", "Enum value not allowed after Type parameter");
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
}

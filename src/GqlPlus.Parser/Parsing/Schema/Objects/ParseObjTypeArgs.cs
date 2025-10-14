using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseObjTypeArgs
  : Parser<IGqlpObjTypeArg>.IA
{
  public IResultArray<IGqlpObjTypeArg> Parse(ITokenizer tokens, string label)
  {
    List<IGqlpObjTypeArg> list = [];

    if (!tokens.Take('<')) {
      return list.EmptyArray();
    }

    IResult<ObjTypeArgAst> argument = ParseObjectArg(tokens, label);
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

  private static IResult<ObjTypeArgAst> ParseObjectArg(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<ObjTypeArgAst>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      ObjTypeArgAst objType = new(at, param!, description) {
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
      return default(ObjTypeArgAst).Empty();
    }

    ObjTypeArgAst argument = new(at, name!, description);

    if (tokens.Take('.')) {
      if (argument.IsTypeParam) {
        return tokens.Error<ObjTypeArgAst>("Output Arg", "Enum value not allowed after Type parameter");
      }

      at = tokens.At;
      if (tokens.Identifier(out string? enumLabel)) {
        argument = argument with { EnumValue = new EnumValueAst(at, argument.Name, enumLabel) };
        return argument.Ok();
      }

      return tokens.Error("Output Arg", "enum value after '.'", argument);
    }

    return argument.Ok();
  }
}

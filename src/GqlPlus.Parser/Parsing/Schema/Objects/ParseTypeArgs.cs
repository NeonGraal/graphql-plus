using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseTypeArgs
  : Parser<IGqlpTypeArg>.IA
{
  public IResultArray<IGqlpTypeArg> Parse(ITokenizer tokens, string label)
  {
    List<IGqlpTypeArg> list = [];

    if (!tokens.Take('<')) {
      return list.EmptyArray();
    }

    IResult<TypeArgAst> argument = ParseObjectArg(tokens, label);
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

  private static IResult<TypeArgAst> ParseObjectArg(ITokenizer tokens, string label)
  {
    string description = tokens.Description();
    IResult<TypeArgAst>? value = ParseParameterArg(tokens, label, description);
    if (value is not null) {
      return value;
    }

    TokenAt at = tokens.At;
    string name = ParseArgName(tokens);
    if (string.IsNullOrWhiteSpace(name)) {
      return default(TypeArgAst).Empty();
    }

    TypeArgAst argument = new(at, name!, description);

    if (tokens.Take('.')) {
      if (argument.IsTypeParam) {
        return tokens.Error<TypeArgAst>("Output Arg", "Enum value not allowed after Type parameter");
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

  private static string ParseArgName(ITokenizer tokens)
  {
    bool hasName = tokens.Identifier(out string? name);
    if (!hasName) {
      if (hasName = tokens.TakeZero()) {
        name = "0";
      } else if (hasName = tokens.TakeAny(out char simple, '^', '*', '_')) {
        name = $"{simple}";
      }
    }

    return name.IfWhiteSpace();
  }

  private static IResult<TypeArgAst>? ParseParameterArg(ITokenizer tokens, string label, string description)
  {
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<TypeArgAst>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      TypeArgAst objType = new(at, param!, description) {
        IsTypeParam = true,
      };
      return objType.Ok();
    }

    return null;
  }
}

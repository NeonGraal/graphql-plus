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

    IResult<TObjArgAst> argument = ParseObjectType(tokens, label).Map(CallArgEnumValue);
    while (argument.Required(list.Add)) {
      argument = ParseObjectType(tokens, label).Map(CallArgEnumValue);
    }

    if (argument.IsError()) {
      return argument.AsResultArray(list);
    } else if (!tokens.Take('>')) {
      return tokens.ErrorArray(label, "'>' after type argument(s)", list);
    } else if (list.Count < 1) {
      return tokens.ErrorArray(label, "at least one type argument after '<'", list);
    }

    return list.OkArray();

    IResult<TObjArgAst> CallArgEnumValue(TObjArgAst value)
      => ArgEnumValue(tokens, value);
  }

  protected IResult<TObjArgAst> ParseObjectType(ITokenizer tokens, string label)

  {
    string description = tokens.Description();
    if (!tokens.Prefix('$', out string? param, out TokenAt at)) {
      return tokens.Error<TObjArgAst>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(param)) {
      TObjArgAst objType = ObjType(at, param!, description) with {
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

    return hasName
      ? ObjType(at, name!, description).Ok()
      : 0.Empty<TObjArgAst>();
  }

  protected virtual IResult<TObjArgAst> ArgEnumValue(ITokenizer tokens, TObjArgAst argument)
    => argument.Ok();

  protected abstract TObjArgAst ObjType(TokenAt at, string type, string description);
}

using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal abstract class ObjectArgumentsParser<TObjArg, TObjArgAst>
  : ObjectTypeParser<TObjArg, TObjArgAst>
  , Parser<TObjArg>.IA
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  public override IResultArray<TObjArg> Parse(ITokenizer tokens, string label)
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

  protected virtual IResult<TObjArgAst> ArgEnumValue(ITokenizer tokens, TObjArgAst argument)

    => argument.Ok();
}

using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseVariables(
  IParserRepository parsers
) : Parser<IAstVariable>.IA
{
  private readonly Parser<IAstVariable>.L _variable = parsers.ParserFor<IAstVariable>();

  public IResultArray<IAstVariable> Parse(ITokenizer tokens, string label)

  {
    List<IAstVariable> list = [];

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    IResult<IAstVariable> variable = _variable.Parse(tokens, label);
    if (variable.IsError()) {
      return variable.AsResultArray(list);
    }

    while (variable.Required(list.Add)) {
      variable = _variable.Parse(tokens, label);
      if (variable.IsError()) {
        return variable.AsResultArray(list);
      }
    }

    return list.Count == 0
      ? tokens.ErrorArray(label, "at least one variable", list)
      : tokens.Take(')')
        ? list.OkArray()
        : tokens.PartialArray(label, "')'.", () => list);
  }

  internal static ParseVariables Factory(IParserRepository p) => new(p);
}

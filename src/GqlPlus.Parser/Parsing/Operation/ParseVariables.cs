using GqlPlus.Abstractions.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseVariables(
  IParserRepository parsers
) : Parser<IGqlpVariable>.IA
{
  private readonly Parser<IGqlpVariable>.L _variable = parsers.ParserFor<IGqlpVariable>();

  public IResultArray<IGqlpVariable> Parse(ITokenizer tokens, string label)

  {
    List<IGqlpVariable> list = [];

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    IResult<IGqlpVariable> variable = _variable.Parse(tokens, label);
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
}

using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal class ParseVariables(
  Parser<VariableAst>.D variable
) : Parser<VariableAst>.IA
{
  private readonly Parser<VariableAst>.L _variable = variable;

  public IResultArray<VariableAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var list = new List<VariableAst>();

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    var variable = _variable.Parse(tokens, label);
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

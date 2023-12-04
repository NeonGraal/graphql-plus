using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseVariables : IParserArray<VariableAst>
{
  private readonly Parser<VariableAst>.L _variable;

  public ParseVariables(Parser<VariableAst>.D variable)
    => _variable = variable;

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

    return list.Any()
      ? tokens.Take(')')
        ? list.OkArray()
        : tokens.PartialArray(label, "')'.", () => list)
      : tokens.ErrorArray(label, "at least one variable", list);
  }
}

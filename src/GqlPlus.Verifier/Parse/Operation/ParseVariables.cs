using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseVariables : IParserArray<VariableAst>
{
  private readonly IParser<VariableAst> _variable;

  public ParseVariables(IParser<VariableAst> variable)
    => _variable = variable;

  public IResultArray<VariableAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var list = new List<VariableAst>();

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    var variable = _variable.Parse(tokens);
    if (variable.IsError()) {
      return variable.AsResultArray(list);
    }

    while (variable.Required(list.Add)) {
      variable = _variable.Parse(tokens);
      if (variable.IsError()) {
        return variable.AsResultArray(list);
      }
    }

    return list.Any()
      ? tokens.Take(')')
        ? list.OkArray()
        : tokens.PartialArray("Variables", "')'.", () => list)
      : tokens.ErrorArray("Variables", "at least one variable", list);
  }
}

using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseParameters : IParserArray<ParameterAst>
{
  private readonly IParser<InputReferenceAst> _input;
  private readonly IParserArray<ModifierAst> _modifiers;
  private readonly IParserDefault _default;

  public ParseParameters(
    IParser<InputReferenceAst> input,
    IParserArray<ModifierAst> modifiers,
    IParserDefault defaultParser)
  {
    _input = input.ThrowIfNull();
    _modifiers = modifiers.ThrowIfNull();
    _default = defaultParser.ThrowIfNull();
  }

  public IResultArray<ParameterAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var list = new List<ParameterAst>();

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(')')) {
      tokens.String(out var descr);
      var at = tokens.At;
      var input = _input.Parse(tokens);
      if (!input.IsOk()) {
        return tokens.ErrorArray("Parameter", "input reference after '('", list);
      }

      var parameter = new ParameterAst(at, input.Required() with { Description = descr });
      list.Add(parameter);
      var modifiers = _modifiers.Parse(tokens, "Parameter");
      if (modifiers.IsError()) {
        return modifiers.AsResultArray(list);
      }

      modifiers.Optional(value => parameter.Modifiers = value);
      var constant = _default.Parse(tokens);
      if (constant.IsError()) {
        return constant.AsResultArray(list);
      }

      constant.Optional(value => parameter.Default = value);
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one parameter after '('", list) : list.OkArray();
  }
}

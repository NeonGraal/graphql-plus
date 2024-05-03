using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema;

internal class ParseParameters(
  Parser<InputBaseAst>.D input,
  Parser<ModifierAst>.DA modifiers,
  Parser<IParserDefault, ConstantAst>.D defaultParser
) : Parser<ParameterAst>.IA
{
  private readonly Parser<InputBaseAst>.L _input = input;
  private readonly Parser<ModifierAst>.LA _modifiers = modifiers;
  private readonly Parser<IParserDefault, ConstantAst>.L _default = defaultParser;

  public IResultArray<ParameterAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<ParameterAst> list = [];

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(')')) {
      TokenAt at = tokens.At;
      IResult<InputBaseAst> input = _input.Parse(tokens, label);
      if (!input.IsOk()) {
        return tokens.ErrorArray("Parameter", "input base after '('", list);
      }

      ParameterAst parameter = new(at, input.Required());
      list.Add(parameter);
      IResultArray<ModifierAst> modifiers = _modifiers.Parse(tokens, "Parameter");
      if (modifiers.IsError()) {
        return modifiers.AsResultArray(list);
      }

      modifiers.Optional(value => parameter.Modifiers = value);
      IResult<ConstantAst> constant = _default.I.Parse(tokens, "Default");
      if (constant.IsError()) {
        return constant.AsResultArray(list);
      }

      constant.Optional(value => parameter.Default = value);
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one parameter after '('", list) : list.OkArray();
  }
}

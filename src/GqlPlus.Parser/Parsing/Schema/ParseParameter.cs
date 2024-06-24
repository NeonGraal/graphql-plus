using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseParameters(
  Parser<IGqlpInputBase>.D input,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IParserDefault, IGqlpConstant>.D defaultParser
) : Parser<IGqlpInputParameter>.IA
{
  private readonly Parser<IGqlpInputBase>.L _input = input;
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<IParserDefault, IGqlpConstant>.L _default = defaultParser;

  public IResultArray<IGqlpInputParameter> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<IGqlpInputParameter> list = [];

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(')')) {
      TokenAt at = tokens.At;
      IResult<IGqlpInputBase> input = _input.Parse(tokens, label);
      if (!input.IsOk()) {
        return tokens.ErrorArray("Parameter", "input reference after '('", list);
      }

      InputParameterAst parameter = new(at, input.Required());
      list.Add(parameter);
      IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, "Parameter");
      if (modifiers.IsError()) {
        return modifiers.AsResultArray(list);
      }

      modifiers.Optional(value => parameter.Modifiers = value.ArrayOf<ModifierAst>());
      IResult<IGqlpConstant> constant = _default.I.Parse(tokens, "Default");
      if (constant.IsError()) {
        return constant.AsResultArray(list);
      }

      constant.Optional(value => parameter.DefaultValue = (ConstantAst?)value);
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one parameter after '('", list) : list.OkArray();
  }
}

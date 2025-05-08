using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputParams(
  Parser<IGqlpInputBase>.D input,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IParserDefault, IGqlpConstant>.D defaultParser
) : Parser<IGqlpInputParam>.IA
{
  private readonly Parser<IGqlpInputBase>.L _input = input;
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<IParserDefault, IGqlpConstant>.L _default = defaultParser;

  public IResultArray<IGqlpInputParam> Parse(ITokenizer tokens, string label)

  {
    List<IGqlpInputParam> list = [];

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(')')) {
      TokenAt at = tokens.At;
      IResult<IGqlpInputBase> input = _input.Parse(tokens, label);
      if (!input.IsOk()) {
        return tokens.ErrorArray("Param", "input reference after '('", list);
      }

      InputParamAst parameter = new(at, input.Required());
      list.Add(parameter);
      IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, "Param");
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

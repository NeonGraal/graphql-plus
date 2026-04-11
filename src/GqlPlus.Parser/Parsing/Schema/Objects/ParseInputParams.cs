using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputParams(
  IParserRepository parsers
) : Parser<IAstInputParam>.IA
{
  private readonly Parser<IAstObjBase>.L _input = parsers.ParserFor<IAstObjBase>();
  private readonly Parser<IAstModifier>.LA _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly Parser<IParserDefault, IAstConstant>.L _default = parsers.ParserFor<IParserDefault, IAstConstant>();

  public IResultArray<IAstInputParam> Parse(ITokenizer tokens, string label)

  {
    List<IAstInputParam> list = [];

    if (!tokens.Take('(')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(')')) {
      TokenAt at = tokens.At;
      IResult<IAstObjBase> input = _input.Parse(tokens, label);
      if (!input.IsOk()) {
        return tokens.ErrorArray("Param", "input reference after '('", list);
      }

      InputParamAst parameter = new(at, input.Required());
      list.Add(parameter);
      IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, "Param");
      if (modifiers.IsError()) {
        return modifiers.AsResultArray(list);
      }

      modifiers.Optional(value => parameter.Modifiers = value.ArrayOf<ModifierAst>());
      IResult<IAstConstant> constant = _default.I.Parse(tokens, "Default");
      if (constant.IsError()) {
        return constant.AsResultArray(list);
      }

      constant.Optional(value => parameter.DefaultValue = value);
    }

    return list.Count == 0 ? tokens.ErrorArray(label, "at least one parameter after '('", list) : list.OkArray();
  }
}

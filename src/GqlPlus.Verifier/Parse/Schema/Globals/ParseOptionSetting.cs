using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;

namespace GqlPlus.Parse.Schema.Globals;

internal class ParseOptionSetting(
  Parser<IParserDefault, ConstantAst>.D defaultParser
) : Parser<OptionSettingAst>.I
{
  private readonly Parser<IParserDefault, ConstantAst>.L _default = defaultParser;

  IResult<OptionSettingAst> Parser<OptionSettingAst>.I.Parse<TContext>(TContext tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    tokens.String(out string? description);
    if (!tokens.Identifier(out string? name)) {
      return 0.Empty<OptionSettingAst>();
    }

    IResult<ConstantAst> constant = _default.I.Parse(tokens, label);
    return constant.SelectOk(
      value => new OptionSettingAst(at, name, value),
      () => tokens.Error<OptionSettingAst>(label, "Value"));
  }
}

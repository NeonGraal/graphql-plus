using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOptionSetting(
  Parser<IParserDefault, ConstantAst>.D defaultParser
) : Parser<OptionSettingAst>.I
{
  private readonly Parser<IParserDefault, ConstantAst>.L _default = defaultParser;

  IResult<OptionSettingAst> Parser<OptionSettingAst>.I.Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;
    tokens.String(out var description);
    if (!tokens.Identifier(out var name)) {
      return 0.Empty<OptionSettingAst>();
    }

    var constant = _default.I.Parse(tokens, label);
    return constant.SelectOk(
      value => new OptionSettingAst(at, name, value),
      () => tokens.Error<OptionSettingAst>(label, "Value"));
  }
}

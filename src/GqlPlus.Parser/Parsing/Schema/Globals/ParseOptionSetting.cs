using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseOptionSetting(
  IParserRepository parsers
) : Parser<IAstSchemaSetting>.I
{
  private readonly Parser<IParserDefault, IAstConstant>.L _default = parsers.ParserFor<IParserDefault, IAstConstant>();

  public IResult<IAstSchemaSetting> Parse(ITokenizer tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    string description = tokens.Description();
    if (!tokens.Identifier(out string? name)) {
      return default(IAstSchemaSetting).Empty();
    }

    IResult<IAstConstant> constant = _default.I.Parse(tokens, label);
    return constant.SelectOk(
      value => new OptionSettingAst(at, name, description, value),
      () => tokens.Error<IAstSchemaSetting>(label, "Value"));
  }
}

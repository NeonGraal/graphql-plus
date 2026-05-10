using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseOptionSetting(
  IParserRepository parsers
) : IParser<IAstSchemaSetting>
{
  private readonly ParserOne<IParserDefault, IAstConstant> _default = parsers.ParserFor<IParserDefault, IAstConstant>();

  public IResult<IAstSchemaSetting> Parse([NotNull] ITokenizer tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    string description = tokens.Description();
    if (!tokens.Identifier(out string? name)) {
      return default(IAstSchemaSetting).Empty();
    }

    IResult<IAstConstant> constant = _default.Parse(tokens, label);
    return constant.SelectOk(
      value => new OptionSettingAst(at, name, description, value),
      () => tokens.Error<IAstSchemaSetting>(label, "Value"));
  }

  internal static ParseOptionSetting Factory(IParserRepository p) => new(p);
}

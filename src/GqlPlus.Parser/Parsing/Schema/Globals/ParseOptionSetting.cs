﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseOptionSetting(
  Parser<IParserDefault, IGqlpConstant>.D defaultParser
) : Parser<IGqlpSchemaSetting>.I
{
  private readonly Parser<IParserDefault, IGqlpConstant>.L _default = defaultParser;

  public IResult<IGqlpSchemaSetting> Parse(ITokenizer tokens, string label)
  {
    Token.TokenAt at = tokens.At;
    string description = tokens.Description();
    if (!tokens.Identifier(out string? name)) {
      return 0.Empty<IGqlpSchemaSetting>();
    }

    IResult<IGqlpConstant> constant = _default.I.Parse(tokens, label);
    return constant.SelectOk(
      value => new OptionSettingAst(at, name, description, value),
      () => tokens.Error<IGqlpSchemaSetting>(label, "Value"));
  }
}

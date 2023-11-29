﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseDirectiveChecks
  : BaseAliasedParserChecks<string, DirectiveAst>
{
  public ParseDirectiveChecks(IParser<DirectiveAst> parser)
    : base(parser) { }

  protected internal override DirectiveAst AliasedFactory(string input)
    => new(AstNulls.At, input) { Locations = DirectiveLocation.Operation };

  protected internal override string AliasesString(string input, string aliases)
    => "@" + input + aliases + "{operation}";
}

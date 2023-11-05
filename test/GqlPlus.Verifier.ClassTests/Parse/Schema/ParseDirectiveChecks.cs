﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseDirectiveChecks
  : BaseAliasedChecks<string, DirectiveAst>
{
  public ParseDirectiveChecks()
    : base((SchemaParser parser, out DirectiveAst? result) => parser.ParseDirectiveDeclaration("").Required(out result))
  { }

  protected internal override DirectiveAst AliasedFactory(string input)
    => new(AstNulls.At, input) { Locations = DirectiveLocation.Operation };

  protected internal override string AliasesString(string input, string aliases)
    => "@" + input + aliases + "=operation";
}

﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema.Types;

public sealed class ParseDomainBooleanTests(
  Parser<AstDomain>.D parser
) : BaseDomainTests<string>
{
  internal override IBaseDomainChecks<string> DomainChecks => _checks;

  private readonly ParseDomainBooleanChecks _checks = new(parser);
}

internal sealed class ParseDomainBooleanChecks(
  Parser<AstDomain>.D parser
) : BaseDomainChecks<string, AstDomain>(parser, DomainDomain.Boolean)
{
  protected internal override AstDomain<DomainTrueFalseAst> NamedFactory(string input)
    => new(AstNulls.At, input, DomainDomain.Boolean, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{boolean}";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}

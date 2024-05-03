using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

public sealed class ParseDomainBooleanTests(
  Parser<AstDomain>.D parser
) : TestDomain<string>
{
  internal override ICheckDomain<string> DomainChecks => _checks;

  private readonly ParseDomainBooleanChecks _checks = new(parser);
}

internal sealed class ParseDomainBooleanChecks(
  Parser<AstDomain>.D parser
) : CheckDomain<string, AstDomain>(parser, DomainKind.Boolean)
{
  protected internal override AstDomain<DomainTrueFalseAst> NamedFactory(string input)
    => new(AstNulls.At, input, DomainKind.Boolean, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{boolean}";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}

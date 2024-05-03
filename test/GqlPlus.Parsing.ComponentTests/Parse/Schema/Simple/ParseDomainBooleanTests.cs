using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parse.Schema.Simple;

public sealed class ParseDomainBooleanTests(
  Parser<IGqlpDomain>.D parser
) : BaseDomainTests<string>
{
  internal override IBaseDomainChecks<string> DomainChecks => _checks;

  private readonly ParseDomainBooleanChecks _checks = new(parser);
}

internal sealed class ParseDomainBooleanChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<string, AstDomain>(parser, DomainKind.Boolean)
{
  protected internal override AstDomain<DomainTrueFalseAst> NamedFactory(string input)
    => new(AstNulls.At, input, DomainKind.Boolean, []);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{boolean}";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}

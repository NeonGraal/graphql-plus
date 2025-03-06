using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public sealed class ParseDomainBooleanTests(
  IBaseDomainChecks<string, IGqlpDomain<IGqlpDomainTrueFalse>> domainChecks
) : BaseDomainTests<string, IGqlpDomain<IGqlpDomainTrueFalse>>(domainChecks)
{ }

internal sealed class ParseDomainBooleanChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<string, AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse>, IGqlpDomain<IGqlpDomainTrueFalse>>(parser, DomainKind.Boolean)
{
  protected internal override AstDomain<DomainTrueFalseAst, IGqlpDomainTrueFalse> NamedFactory(string input)
    => new(AstNulls.At, input, DomainKind.Boolean, [new(AstNulls.At, false, false), new(AstNulls.At, false, true)]);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{boolean}";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}

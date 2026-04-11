using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parser.Schema.Simple;

public sealed class ParseDomainBooleanTests(
  IBaseDomainChecks<string, IAstDomain<IAstDomainTrueFalse>> domainChecks
) : BaseDomainTests<string, IAstDomain<IAstDomainTrueFalse>>(domainChecks)
{ }

internal sealed class ParseDomainBooleanChecks(
  IParserRepository parsers
) : BaseDomainChecks<string, AstDomain<DomainTrueFalseAst, IAstDomainTrueFalse>, IAstDomain<IAstDomainTrueFalse>>(parsers, DomainKind.Boolean)
{
  protected internal override AstDomain<DomainTrueFalseAst, IAstDomainTrueFalse> NamedFactory(string input)
    => new(AstNulls.At, input, DomainKind.Boolean, [new DomainTrueFalseAst(AstNulls.At, "", false, false), new DomainTrueFalseAst(AstNulls.At, "", false, true)]);

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{boolean}";
  protected internal override string KindString(string input, string kind, string parent)
    => input + "{" + parent + kind + "}";
}

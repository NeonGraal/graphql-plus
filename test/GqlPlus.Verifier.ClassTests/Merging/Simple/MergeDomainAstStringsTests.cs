using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Simple;

public class MergeDomainAstStringsTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainRegexAst, string>(outputHelper)
{
  protected override DomainRegexAst[] MakeItems(string input)
    => new[] { input }.DomainRegexes();

  protected override AstDomain<DomainRegexAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, DomainKind.String);
}

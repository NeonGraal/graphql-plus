using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainAstStringsTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainRegexAst, string>(outputHelper)
{
  protected override DomainRegexAst[] MakeItems(string input)
    => new[] { input }.DomainRegexes();

}

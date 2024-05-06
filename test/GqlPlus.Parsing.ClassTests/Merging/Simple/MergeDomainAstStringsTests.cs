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

  protected override AstDomain<DomainRegexAst> MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => new(AstNulls.At, name, description, DomainKind.String) { Aliases = aliases ?? [], Parent = parent, };
}

using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainAstNumbersTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainRangeAst, DomainRangeInput>(outputHelper)
{
  protected override DomainRangeAst[] MakeItems(DomainRangeInput input)
    => input.DomainRange();

  protected override AstDomain<DomainRangeAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, DomainKind.Number);
}

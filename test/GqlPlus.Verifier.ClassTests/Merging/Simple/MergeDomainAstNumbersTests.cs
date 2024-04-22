using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Types;

public class MergeDomainAstNumbersTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainRangeAst, DomainRangeInput>(outputHelper)
{
  protected override DomainRangeAst[] MakeItems(DomainRangeInput input)
    => input.DomainRange();

  protected override AstDomain<DomainRangeAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, DomainDomain.Number);
}

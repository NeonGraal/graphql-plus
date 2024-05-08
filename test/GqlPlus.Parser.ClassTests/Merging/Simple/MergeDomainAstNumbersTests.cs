using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainAstNumbersTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainRangeAst, IGqlpDomainRange, DomainRangeInput>(outputHelper)
{
  protected override DomainRangeAst[] MakeItems(DomainRangeInput input)
    => input.DomainRange();

  protected override AstDomain<DomainRangeAst, IGqlpDomainRange> MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => new(AstNulls.At, name, description, DomainKind.Number) {
      Aliases = aliases ?? [],
      Parent = parent
    };
}

﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainAstNumbersTests
  : TestDomainMerger<IGqlpDomainRange, DomainRangeInput>
{
  internal override IDomainMerger<IGqlpDomainRange> Merger { get; }
  internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<IGqlpDomainRange>, string, IGqlpDomainRange> MergerTyped { get; }

  public MergeDomainAstNumbersTests(ITestOutputHelper outputHelper)
  {
    MergeDomains<DomainRangeAst, IGqlpDomainRange> merger = new(outputHelper.ToLoggerFactory(), MergeItems);
    MergerTyped = merger;
    Merger = merger;
  }

  protected override IGqlpDomain<IGqlpDomainRange> MakeDomain(string name, string[]? aliases = null, string description = "", string? parent = null, DomainKind? kind = null, IEnumerable<IGqlpDomainRange>? items = null)
    => new AstDomain<DomainRangeAst, IGqlpDomainRange>(AstNulls.At, name, description, kind ?? DomainKind.Boolean) {
      Aliases = aliases ?? [],
      Parent = parent,
      Items = items?.ArrayOf<DomainRangeAst>() ?? [],
    };

  protected override IGqlpDomainRange[] MakeItems(DomainRangeInput input)
    => input.DomainRange();
}

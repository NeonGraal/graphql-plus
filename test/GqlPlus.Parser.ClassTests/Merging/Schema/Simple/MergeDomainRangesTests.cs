﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainRangesTests(
  ITestOutputHelper outputHelper
) : TestDomainItemMerger<IGqlpDomainRange, DomainRangeInput>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameExcludes_ReturnsGood(DomainRangeInput input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(DomainRangeInput input)
    => CanMerge_Errors([MakeItem(input, true), MakeAst(input)]);

  private readonly MergeDomainRanges _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainRange> MergerGroups => _merger;

  protected override IGqlpDomainRange MakeItem(DomainRangeInput input, bool excludes)
    => new DomainRangeAst(AstNulls.At, "", excludes, input.Lower, input.Upper);
}

﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainRegexesTests(
  ITestOutputHelper outputHelper
) : TestDomainItemMerger<IGqlpDomainRegex, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeItem(name, true), MakeAst(name)]);

  private readonly MergeDomainRegexes _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainRegex> MergerGroups => _merger;

  protected override IGqlpDomainRegex MakeItem(string input, bool excludes)
    => new DomainRegexAst(AstNulls.At, "", excludes, input);
  protected override bool InputEquals(string? input1, string? input2)
    => string.Equals(input1, input2, StringComparison.Ordinal);
}

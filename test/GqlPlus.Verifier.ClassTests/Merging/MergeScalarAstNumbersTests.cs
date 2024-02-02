﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstNumbersTests
  : TestDescriptions<AstScalar<ScalarRangeAst>>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameKinds_ReturnsTrue(string name)
  {
    var items = new[] { MakeDescribed(name), MakeDescribed(name) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentKinds_ReturnsFalse(string name)
  {
    var items = new[] { MakeDescribed(name) with { Kind = ScalarKind.String }, MakeDescribed(name) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsRangesCantMerge_ReturnsFalse(string name, ScalarRangeInput range)
  {
    var items = new[] {
      MakeDescribed(name) with { Items = range.ScalarRange() },
      MakeDescribed(name) with { Items = range.ScalarRange() },
    };
    _ranges.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  private readonly IMerge<ScalarRangeAst> _ranges;
  private readonly MergeScalars<ScalarRangeAst> _merger;

  public MergeScalarAstNumbersTests()
  {
    _ranges = Merger<ScalarRangeAst>();

    _merger = new(_ranges);
  }

  internal override GroupsMerger<AstScalar<ScalarRangeAst>> MergerGroups => _merger;

  protected override AstScalar<ScalarRangeAst> MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarKind.Number);
}

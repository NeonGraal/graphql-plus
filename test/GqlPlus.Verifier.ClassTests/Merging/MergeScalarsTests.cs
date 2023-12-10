﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarsTests
  : TestDescriptions<ScalarDeclAst>
{
  private readonly IMerge<ScalarRangeAst> _ranges;
  private readonly IMerge<ScalarRegexAst> _regexes;
  private readonly MergeScalars _merger;

  public MergeScalarsTests()
  {
    _ranges = Substitute.For<IMerge<ScalarRangeAst>>();
    _ranges.CanMerge([]).ReturnsForAnyArgs(true);
    _regexes = Substitute.For<IMerge<ScalarRegexAst>>();
    _regexes.CanMerge([]).ReturnsForAnyArgs(true);

    _merger = new(_ranges, _regexes);
  }

  protected override DescribedMerger<ScalarDeclAst> MergerDescribed => _merger;

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameKinds_ReturnsTrue(string name)
  {
    var items = new[] { new ScalarDeclAst(AstNulls.At, name), new ScalarDeclAst(AstNulls.At, name) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentKinds_ReturnsFalse(string name)
  {
    var items = new[] { new ScalarDeclAst(AstNulls.At, name) { Kind = ScalarKind.String }, new ScalarDeclAst(AstNulls.At, name) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsRangesCantMerge_ReturnsFalse(string name)
  {
    var items = new[] { new ScalarDeclAst(AstNulls.At, name), new ScalarDeclAst(AstNulls.At, name) };
    _ranges.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsRegexesCantMerge_ReturnsFalse(string name)
  {
    var items = new[] { new ScalarDeclAst(AstNulls.At, name), new ScalarDeclAst(AstNulls.At, name) };
    _regexes.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  protected override ScalarDeclAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}

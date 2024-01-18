using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarsTests
  : TestDescriptions<ScalarDeclAst>
{
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
  public void CanMerge_TwoItemsRangesCantMerge_ReturnsFalse(string name, RangeInput range)
  {
    var items = new[] {
      new ScalarDeclAst(AstNulls.At, name) with { Numbers = range.ScalarRanges() },
      new ScalarDeclAst(AstNulls.At, name) with { Numbers = range.ScalarRanges() },
    };
    _ranges.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsRegexesCantMerge_ReturnsFalse(string name, string regex)
  {
    var items = new[] {
      new ScalarDeclAst(AstNulls.At, name) with { Regexes = regex.ScalarRegexes() },
      new ScalarDeclAst(AstNulls.At, name) with { Regexes = regex.ScalarRegexes() },
    };
    _regexes.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  private readonly IMerge<ScalarRangeNumberAst> _ranges;
  private readonly IMerge<ScalarRegexAst> _regexes;
  private readonly MergeScalars _merger;

  public MergeScalarsTests()
  {
    _ranges = Merger<ScalarRangeNumberAst>();
    _regexes = Merger<ScalarRegexAst>();

    _merger = new(_ranges, _regexes);
  }

  protected override GroupsMerger<ScalarDeclAst> MergerGroups => _merger;

  protected override ScalarDeclAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}

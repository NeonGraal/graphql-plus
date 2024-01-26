using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstUnionsTests
  : TestDescriptions<AstScalar<ScalarReferenceAst>>
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

  //[Theory, RepeatData(Repeats)]
  //public void CanMerge_TwoItemsRangesCantMerge_ReturnsFalse(string name, RangeUnionInput range)
  //{
  //  var items = new[] {
  //    MakeDescribed(name) with { Members = range.ScalarRanges() },
  //    MakeDescribed(name) with { Members = range.ScalarRanges() },
  //  };
  //  _ranges.CanMerge([]).ReturnsForAnyArgs(false);

  //  var result = _merger.CanMerge(items);

  //  result.Should().BeFalse();
  //}

  //[Theory, RepeatData(Repeats)]
  //public void CanMerge_TwoItemsRegexesCantMerge_ReturnsFalse(string name, string regex)
  //{
  //  var items = new[] {
  //    MakeDescribed(name) with { Members = regex.ScalarRegexes() },
  //    MakeDescribed(name) with { Members = regex.ScalarRegexes() },
  //  };
  //  _regexes.CanMerge([]).ReturnsForAnyArgs(false);

  //  var result = _merger.CanMerge(items);

  //  result.Should().BeFalse();
  //}

  private readonly IMerge<ScalarReferenceAst> _references;
  private readonly MergeScalars<ScalarReferenceAst> _merger;

  public MergeScalarAstUnionsTests()
  {
    _references = Merger<ScalarReferenceAst>();

    _merger = new(_references);
  }

  protected override GroupsMerger<AstScalar<ScalarReferenceAst>> MergerGroups => _merger;

  protected override AstScalar<ScalarReferenceAst> MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarKind.Union);
}

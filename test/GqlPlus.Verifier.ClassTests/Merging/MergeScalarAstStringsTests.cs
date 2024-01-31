using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstStringsTests
  : TestDescriptions<AstScalar<ScalarRegexAst>>
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
    var items = new[] { MakeDescribed(name) with { Kind = ScalarKind.Number }, MakeDescribed(name) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsRegexesCantMerge_ReturnsFalse(string name, string regex)
  {
    var items = new[] {
      MakeDescribed(name) with { Items = regex.ScalarRegexes() },
      MakeDescribed(name) with { Items = regex.ScalarRegexes() },
    };
    _regexes.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  private readonly IMerge<ScalarRegexAst> _regexes;
  private readonly MergeScalars<ScalarRegexAst> _merger;

  public MergeScalarAstStringsTests()
  {
    _regexes = Merger<ScalarRegexAst>();

    _merger = new(_regexes);
  }

  protected override GroupsMerger<AstScalar<ScalarRegexAst>> MergerGroups => _merger;

  protected override AstScalar<ScalarRegexAst> MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarKind.String);
}

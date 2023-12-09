using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeParametersTests
  : TestDescriptions<ParameterAst>
{
  private readonly MergeParameters _merger = new();

  protected override DescribedMerger<ParameterAst> Merger => _merger;

  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
  {
    var items = Array.Empty<ParameterAst>();

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneItem_ReturnsTrue(string input)
  {
    var items = new[] { new ParameterAst(AstNulls.At, input) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameModifers_ReturnsTrue(string input)
  {
    var items = new[] { new ParameterAst(AstNulls.At, input) { Modifiers = TestMods() }, new ParameterAst(AstNulls.At, input) { Modifiers = TestMods() } };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentModifers_ReturnsFalse(string input)
  {
    var items = new[] { new ParameterAst(AstNulls.At, input) { Modifiers = TestMods() }, new ParameterAst(AstNulls.At, input) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  protected override ParameterAst MakeItem(string name, string description = "")
    => new(AstNulls.At, new InputReferenceAst(AstNulls.At, name) with { Description = description });
}

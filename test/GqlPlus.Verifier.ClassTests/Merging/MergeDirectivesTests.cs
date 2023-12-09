using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeDirectivesTests
  : TestDescriptions<DirectiveDeclAst>
{
  private readonly MergeDirectives _merger;
  private readonly IMerge<ParameterAst> _paremeters;

  public MergeDirectivesTests()
  {
    _paremeters = Substitute.For<IMerge<ParameterAst>>();
    _paremeters.CanMerge([]).ReturnsForAnyArgs(true);

    _merger = new(_paremeters);
  }

  protected override DescribedMerger<DirectiveDeclAst> Merger => _merger;

  [Fact]
  public void CanMerge_NoItems_ReturnsFalse()
  {
    var items = Array.Empty<DirectiveDeclAst>();

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_OneItem_ReturnsTrue(string name)
  {
    var items = new[] { new DirectiveDeclAst(AstNulls.At, name) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameOption_ReturnsTrue(string name)
  {
    var items = new[] {
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable },
      new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable }
    };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentOption_ReturnsFalse(string name)
  {
    var items = new[] { new DirectiveDeclAst(AstNulls.At, name) { Option = DirectiveOption.Repeatable }, new DirectiveDeclAst(AstNulls.At, name) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsParametersCantMerge_ReturnsFalse(string name)
  {
    var items = new[] { new DirectiveDeclAst(AstNulls.At, name), new DirectiveDeclAst(AstNulls.At, name) };
    _paremeters.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  protected override DirectiveDeclAst MakeItem(string name, string description = "")
    => new(AstNulls.At, name, description);
}

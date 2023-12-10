using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeParametersTests
  : TestAlternates<ParameterAst, InputReferenceAst>
{
  private readonly MergeParameters _merger = new();

  protected override AlternatesMerger<ParameterAst, InputReferenceAst> MergerAlternate => _merger;

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneDefault_ReturnsTrue(string input, string value)
  {
    var items = new[] { new ParameterAst(AstNulls.At, input) { Default = value.FieldKey() }, new ParameterAst(AstNulls.At, input) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameDefault_ReturnsTrue(string input, string value)
  {
    var items = new[] { new ParameterAst(AstNulls.At, input) { Default = value.FieldKey() }, new ParameterAst(AstNulls.At, input) { Default = value.FieldKey() } };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDefault_ReturnsFalse(string input, string value1, string value2)
  {
    if (value1 == value2) {
      return;
    }

    var items = new[] { new ParameterAst(AstNulls.At, input) { Default = value1.FieldKey() }, new ParameterAst(AstNulls.At, input) { Default = value2.FieldKey() } };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  protected override ParameterAst MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new InputReferenceAst(AstNulls.At, name) with { Description = description });
}

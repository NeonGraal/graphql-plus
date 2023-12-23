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
    => CanMerge_True([MakeAlternate(input), MakeAlternate(input) with { Default = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameDefault_ReturnsTrue(string input, string value)
    => CanMerge_True([
      MakeAlternate(input) with { Default = value.FieldKey() },
      MakeAlternate(input) with { Default = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDefault_ReturnsFalse(string input, string value1, string value2)
    => CanMerge_False([
      MakeAlternate(input) with { Default = value1.FieldKey() },
      MakeAlternate(input) with { Default = value2.FieldKey() }],
      value1 == value2);

  protected override ParameterAst MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new InputReferenceAst(AstNulls.At, name, description));
}

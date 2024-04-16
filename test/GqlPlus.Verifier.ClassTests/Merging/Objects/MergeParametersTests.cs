using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Objects;

public class MergeParametersTests : TestAlternates<ParameterAst, InputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDefault_ReturnsGood(string input, string value)
    => CanMerge_Good([MakeAlternate(input), MakeAlternate(input) with { Default = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDefault_ReturnsGood(string input, string value)
    => CanMerge_Good([
      MakeAlternate(input) with { Default = value.FieldKey() },
      MakeAlternate(input) with { Default = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDefault_ReturnsErrors(string input, string value)
  {
    _constant.CanMerge([]).ReturnsForAnyArgs(ErrorMessages);

    CanMerge_Errors([
      MakeAlternate(input) with { Default = value.FieldKey() },
      MakeAlternate(input) with { Default = value.FieldKey() }]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDefault_ReturnsExpected(string input, string value)
    => Merge_Expected(
      [MakeAlternate(input), MakeAlternate(input) with { Default = value.FieldKey() }],
      MakeAlternate(input) with { Default = value.FieldKey() });

  private readonly IMerge<ConstantAst> _constant;
  private readonly MergeParameters _merger;

  public MergeParametersTests(ITestOutputHelper outputHelper)
  {
    _constant = Merger<ConstantAst>();

    _merger = new(outputHelper.ToLoggerFactory(), _constant);
  }

  internal override AstAlternatesMerger<ParameterAst, InputReferenceAst> MergerAlternate => _merger;

  protected override ParameterAst MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new InputReferenceAst(AstNulls.At, name, description));
}

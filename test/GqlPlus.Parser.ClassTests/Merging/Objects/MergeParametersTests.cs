using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeParametersTests : TestAlternates<InputParameterAst, InputBaseAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDefault_ReturnsGood(string input, string value)
    => CanMerge_Good([MakeAlternate(input), MakeAlternate(input) with { DefaultValue = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDefault_ReturnsGood(string input, string value)
    => CanMerge_Good([
      MakeAlternate(input) with { DefaultValue = value.FieldKey() },
      MakeAlternate(input) with { DefaultValue = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDefault_ReturnsErrors(string input, string value)
    => this
      .CanMergeReturnsError(_constant)
      .CanMerge_Errors(
        MakeAlternate(input) with { DefaultValue = value.FieldKey() },
        MakeAlternate(input) with { DefaultValue = value.FieldKey() });

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDefault_ReturnsExpected(string input, string value)
    => Merge_Expected(
      [MakeAlternate(input), MakeAlternate(input) with { DefaultValue = value.FieldKey() }],
      MakeAlternate(input) with { DefaultValue = value.FieldKey() });

  private readonly IMerge<IGqlpConstant> _constant;
  private readonly MergeParameters _merger;

  public MergeParametersTests(ITestOutputHelper outputHelper)
  {
    _constant = Merger<IGqlpConstant>();

    _merger = new(outputHelper.ToLoggerFactory(), _constant);
  }

  internal override AstAlternatesMerger<InputParameterAst, InputBaseAst> MergerAlternate => _merger;

  protected override InputParameterAst MakeAlternate(string name, string description = "")
    => new(AstNulls.At, new InputBaseAst(AstNulls.At, name, description));
}

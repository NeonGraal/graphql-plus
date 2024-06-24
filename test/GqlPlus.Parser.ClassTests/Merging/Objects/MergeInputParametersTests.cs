using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeInputParametersTests
  : TestDescriptionsMerger<IGqlpInputParameter>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDefault_ReturnsGood(string input, string value)
    => CanMerge_Good([MakeDescribed(input), MakeDescribed(input) with { DefaultValue = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDefault_ReturnsGood(string input, string value)
    => CanMerge_Good([
      MakeDescribed(input) with { DefaultValue = value.FieldKey() },
      MakeDescribed(input) with { DefaultValue = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDefault_ReturnsErrors(string input, string value)
    => this
      .CanMergeReturnsError(_constant)
      .CanMerge_Errors(
        MakeDescribed(input) with { DefaultValue = value.FieldKey() },
        MakeDescribed(input) with { DefaultValue = value.FieldKey() });

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDefault_ReturnsExpected(string input, string value)
    => Merge_Expected(
      [MakeDescribed(input), MakeDescribed(input) with { DefaultValue = value.FieldKey() }],
      MakeDescribed(input) with { DefaultValue = value.FieldKey() });

  private readonly IMerge<IGqlpConstant> _constant;
  private readonly MergeInputParameters _merger;

  public MergeInputParametersTests(ITestOutputHelper outputHelper)
  {
    _constant = Merger<IGqlpConstant>();

    _merger = new(outputHelper.ToLoggerFactory(), _constant);
  }

  internal override GroupsMerger<IGqlpInputParameter> MergerGroups => _merger;

  protected override InputParameterAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, new InputBaseAst(AstNulls.At, name, description));
}

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
    => CanMerge_Good([MakeDescribed(input), MakeDefault(input, value)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDefault_ReturnsGood(string input, string value)
    => CanMerge_Good([
      MakeDefault(input, value),
      MakeDefault(input, value)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDefault_ReturnsErrors(string input, string value)
    => this
      .CanMergeReturnsError(_constant)
      .CanMerge_Errors(
        MakeDefault(input, value),
        MakeDefault(input, value));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDefault_ReturnsExpected(string input, string value)
    => Merge_Expected(
      [MakeDescribed(input), MakeDefault(input, value)],
      MakeDefault(input, value));

  private readonly IMerge<IGqlpConstant> _constant;
  private readonly MergeInputParameters _merger;

  public MergeInputParametersTests(ITestOutputHelper outputHelper)
  {
    _constant = Merger<IGqlpConstant>();

    _merger = new(outputHelper.ToLoggerFactory(), _constant);
  }

  internal override GroupsMerger<IGqlpInputParameter> MergerGroups => _merger;

  protected override IGqlpInputParameter MakeDescribed(string name, string description = "")
    => new InputParameterAst(AstNulls.At, new InputBaseAst(AstNulls.At, name, description));
  private static InputParameterAst MakeDefault(string name, string value)
    => new(AstNulls.At, new InputBaseAst(AstNulls.At, name)) {
      DefaultValue = value.FieldKey()
    };
}

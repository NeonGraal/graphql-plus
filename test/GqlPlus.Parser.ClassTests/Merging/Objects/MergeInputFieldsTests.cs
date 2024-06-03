using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

using Xunit.Abstractions;

namespace GqlPlus.Merging.Objects;

public class MergeInputFieldsTests
  : TestObjectFields<InputFieldAst, IGqlpInputBase>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDefault_ReturnsGood(string name, string type, string value)
    => CanMerge_Good([MakeField(name, type), MakeField(name, type) with { DefaultValue = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDefault_ReturnsGood(string name, string type, string value)
    => CanMerge_Good([
      MakeField(name, type) with { DefaultValue = value.FieldKey() },
      MakeField(name, type) with { DefaultValue = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDefaults_ReturnsErrors(string name, string type, string value)
    => this
      .CanMergeReturnsError(_constant)
      .CanMerge_Errors(
        MakeField(name, type) with { DefaultValue = value.FieldKey() },
        MakeField(name, type) with { DefaultValue = value.FieldKey() });

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDefault_ReturnsExpected(string name, string type, string value)
    => Merge_Expected(
      [MakeField(name, type), MakeField(name, type) with { DefaultValue = value.FieldKey() }],
      MakeField(name, type) with { DefaultValue = value.FieldKey() });

  private readonly IMerge<IGqlpConstant> _constant;
  private readonly MergeInputFields _merger;

  public MergeInputFieldsTests(ITestOutputHelper outputHelper)
  {
    _constant = Merger<IGqlpConstant>();

    _merger = new(outputHelper.ToLoggerFactory(), _constant);
  }

  internal override AstObjectFieldsMerger<InputFieldAst, IGqlpInputBase> MergerField => _merger;

  protected override InputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new InputBaseAst(AstNulls.At, type, typeDescription));
}

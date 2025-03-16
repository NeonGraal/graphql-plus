using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Schema.Objects;

public class MergeInputFieldsTests
  : TestObjectFields<IGqlpInputField, IGqlpInputBase>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneDefault_ReturnsGood(string name, string type, string value)
    => CanMerge_Good([MakeField(name, type), MakeFieldDefault(name, type, value)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameDefault_ReturnsGood(string name, string type, string value)
    => CanMerge_Good([
      MakeFieldDefault(name, type, value),
      MakeFieldDefault(name, type, value)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentDefaults_ReturnsErrors(string name, string type, string value)
    => this
      .CanMergeReturnsError(_constant)
      .CanMerge_Errors(
        MakeFieldDefault(name, type, value),
        MakeFieldDefault(name, type, value));

  [Theory, RepeatData]
  public void Merge_TwoAstsOneDefault_ReturnsExpected(string name, string type, string value)
    => Merge_Expected(
      [MakeField(name, type), MakeFieldDefault(name, type, value)],
      MakeFieldDefault(name, type, value));

  private readonly IMerge<IGqlpConstant> _constant;
  private readonly MergeInputFields _merger;

  public MergeInputFieldsTests(ITestOutputHelper outputHelper)
  {
    _constant = Merger<IGqlpConstant>();

    _merger = new(outputHelper.ToLoggerFactory(), _constant);
  }

  internal override AstObjectFieldsMerger<IGqlpInputField> MergerField => _merger;

  protected override IGqlpInputField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new InputFieldAst(AstNulls.At, name, fieldDescription, new InputBaseAst(AstNulls.At, type, typeDescription));

  internal static IGqlpInputField MakeFieldDefault(string name, string type, string defaultValue)
    => new InputFieldAst(AstNulls.At, name, new InputBaseAst(AstNulls.At, type)) {
      DefaultValue = new(defaultValue.FieldKey())
    };
  protected override IGqlpInputField MakeFieldModifiers(string name)
    => new InputFieldAst(AstNulls.At, name, new InputBaseAst(AstNulls.At, name)) {
      Modifiers = TestMods()
    };
  protected override IGqlpInputField MakeAliased(string name, string[] aliases, string description = "")
    => new InputFieldAst(AstNulls.At, name, description, new InputBaseAst(AstNulls.At, name, description)) {
      Aliases = aliases
    };
}

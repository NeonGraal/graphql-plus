﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeInputFieldsTests
  : TestObjectFieldMerger<IGqlpInputField, IGqlpInputBase>
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

  protected override IGqlpInputField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new InputFieldAst(AstNulls.At, name, fieldDescription, new InputBaseAst(AstNulls.At, type, typeDescription)) {
      Aliases = aliases ?? [],
    };
  internal static IGqlpInputField MakeFieldDefault(string name, string type, string defaultValue)
    => new InputFieldAst(AstNulls.At, name, new InputBaseAst(AstNulls.At, type)) {
      DefaultValue = new ConstantAst(defaultValue.FieldKey()),
    };
  protected override IGqlpInputField MakeFieldModifiers(string name)
    => new InputFieldAst(AstNulls.At, name, new InputBaseAst(AstNulls.At, name)) {
      Modifiers = TestMods(),
    };
  protected override IGqlpInputField MakeFieldEnum(string name, string enumType, string enumLabel, string fieldDescription = "", string typeDescription = "", string[]? aliases = null)
    => new InputFieldAst(AstNulls.At, name, fieldDescription, new InputBaseAst(AstNulls.At, enumType, typeDescription)) {
      Aliases = aliases ?? [],
      EnumLabel = enumLabel,
    };
}

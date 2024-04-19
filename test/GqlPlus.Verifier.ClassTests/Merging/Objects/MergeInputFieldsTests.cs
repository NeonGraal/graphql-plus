﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Objects;

public class MergeInputFieldsTests : TestFields<InputFieldAst, InputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDefault_ReturnsGood(string name, string type, string value)
    => CanMerge_Good([MakeField(name, type), MakeField(name, type) with { Default = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDefault_ReturnsGood(string name, string type, string value)
    => CanMerge_Good([
      MakeField(name, type) with { Default = value.FieldKey() },
      MakeField(name, type) with { Default = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDefaults_ReturnsErrors(string name, string type, string value)
    => this
      .CanMergeReturnsError(_constant)
      .CanMerge_Errors(
        MakeField(name, type) with { Default = value.FieldKey() },
        MakeField(name, type) with { Default = value.FieldKey() });

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneDefault_ReturnsExpected(string name, string type, string value)
    => Merge_Expected(
      [MakeField(name, type), MakeField(name, type) with { Default = value.FieldKey() }],
      MakeField(name, type) with { Default = value.FieldKey() });

  private readonly IMerge<ConstantAst> _constant;
  private readonly MergeInputFields _merger;

  public MergeInputFieldsTests(ITestOutputHelper outputHelper)
  {
    _constant = Merger<ConstantAst>();

    _merger = new(outputHelper.ToLoggerFactory(), _constant);
  }

  internal override FieldsMerger<InputFieldAst, InputReferenceAst> MergerField => _merger;

  protected override InputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));
}

using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeInputFieldsTests(
  ITestOutputHelper outputHelper
) : TestFields<InputFieldAst, InputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneDefault_ReturnsTrue(string name, string type, string value)
    => CanMerge_True([MakeField(name, type), MakeField(name, type) with { Default = value.FieldKey() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameDefault_ReturnsTrue(string name, string type, string value)
    => CanMerge_True([
      MakeField(name, type) with { Default = value.FieldKey() },
      MakeField(name, type) with { Default = value.FieldKey() }]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentDefaults_ReturnsFalse(string name, string type, string value1, string value2)
    => CanMerge_False([
      MakeField(name, type) with { Default = value1.FieldKey() },
      MakeField(name, type) with { Default = value2.FieldKey() }],
      value1 == value2);

  private readonly MergeInputFields _merger = new(outputHelper.ToLoggerFactory());

  internal override FieldsMerger<InputFieldAst, InputReferenceAst> MergerField => _merger;

  protected override InputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));
}

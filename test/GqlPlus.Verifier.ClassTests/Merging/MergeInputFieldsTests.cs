using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeInputFieldsTests
  : TestFields<InputFieldAst, InputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneDefault_ReturnsTrue(string name, string type, string value)
  {
    var items = new[] { MakeField(name, type) with { Default = value.FieldKey() }, MakeField(name, type) };

    var result = MergerField.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameDefault_ReturnsTrue(string name, string type, string value)
  {
    var items = new[] { MakeField(name, type) with { Default = value.FieldKey() }, MakeField(name, type) with { Default = value.FieldKey() } };

    var result = MergerField.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentDefaults_ReturnsFalse(string name, string type, string value1, string value2)
  {
    if (value1 == value2) {
      return;
    }

    var items = new[] { MakeField(name, type) with { Default = value1.FieldKey() }, MakeField(name, type) with { Default = value2.FieldKey() } };

    var result = MergerField.CanMerge(items);

    result.Should().BeFalse();
  }

  private readonly MergeInputFields _merger = new();

  protected override FieldsMerger<InputFieldAst, InputReferenceAst> MergerField => _merger;

  protected override InputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));
}

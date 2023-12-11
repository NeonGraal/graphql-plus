using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestFields<TField, TReference>
  : TestModified<TField>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected abstract FieldsMerger<TField, TReference> MergerField { get; }
  protected override DescribedsMerger<TField> MergerDescribed => MergerField;

  protected abstract TField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "");
  protected override TField MakeDescribed(string name, string description = "")
    => MakeField(name, name, description);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameType_ReturnsTrue(string name, string type)
  {
    var items = new[] { MakeField(name, type), MakeField(name, type) };

    var result = MergerField.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentTypes_ReturnsFalse(string name, string type1, string type2)
  {
    if (type1 == type2) {
      return;
    }

    var items = new[] { MakeField(name, type1), MakeField(name, type2) };

    var result = MergerField.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneTypeDescription_ReturnsTrue(string name, string type, string description)
  {
    var items = new[] { MakeField(name, type, typeDescription: description), MakeField(name, type) };

    var result = MergerField.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameTypeDescription_ReturnsTrue(string name, string type, string description)
  {
    var items = new[] { MakeField(name, type, typeDescription: description), MakeField(name, type, typeDescription: description) };

    var result = MergerField.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentTypeDescriptions_ReturnsFalse(string name, string type, string description1, string description2)
  {
    if (description1 == description2) {
      return;
    }

    var items = new[] { MakeField(name, type, typeDescription: description1), MakeField(name, type, typeDescription: description2) };

    var result = MergerField.CanMerge(items);

    result.Should().BeFalse();
  }
}

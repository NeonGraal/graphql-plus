using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestFields<TField, TReference>
  : TestAliased<TField>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameModifers_ReturnsTrue(string input)
    => CanMerge_True([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentModifers_ReturnsFalse(string input)
    => CanMerge_False([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }],
      MakeDescribed(input) with { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameType_ReturnsTrue(string name, string type)
  => CanMerge_True([MakeField(name, type), MakeField(name, type)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentTypes_ReturnsFalse(string name, string type1, string type2)
    => CanMerge_False([MakeField(name, type1), MakeField(name, type2)], type1 == type2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneTypeDescription_ReturnsTrue(string name, string type, string description)
  => CanMerge_True([MakeField(name, type, typeDescription: description), MakeField(name, type)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameTypeDescription_ReturnsTrue(string name, string type, string description)
  => CanMerge_True([MakeField(name, type, typeDescription: description), MakeField(name, type, typeDescription: description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentTypeDescriptions_ReturnsFalse(string name, string type, string description1, string description2)
  => CanMerge_False([
    MakeField(name, type, typeDescription: description1),
    MakeField(name, type, typeDescription: description2)],
    description1 == description2);

  protected abstract FieldsMerger<TField, TReference> MergerField { get; }
  protected override GroupsMerger<TField> MergerGroups => MergerField;

  protected abstract TField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "");
  protected override TField MakeAliased(string name, string[] aliases, string description = "")
    => MakeField(name, name, description, description) with { Aliases = aliases };
}

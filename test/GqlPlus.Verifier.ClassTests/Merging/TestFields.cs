using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public abstract class TestFields<TField, TReference>
  : TestAliased<TField>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameModifers_ReturnsTrue(string input)
    => CanMerge_True([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentModifers_ReturnsFalse(string input)
    => CanMerge_False([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }],
      MakeDescribed(input) with { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameType_ReturnsTrue(string name, string type)
  => CanMerge_True([MakeField(name, type), MakeField(name, type)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentTypes_ReturnsFalse(string name, string type1, string type2)
    => CanMerge_False([MakeField(name, type1), MakeField(name, type2)], type1 == type2);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameType_ReturnsExpected(string name, string type)
    => Merge_Expected(
      [MakeField(name, type), MakeField(name, type)],
      MakeField(name, type));

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneTypeDescription_ReturnsTrue(string name, string type, string description)
  => CanMerge_True([MakeField(name, type), MakeField(name, type, typeDescription: description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameTypeDescription_ReturnsTrue(string name, string type, string description)
  => CanMerge_True([MakeField(name, type, typeDescription: description), MakeField(name, type, typeDescription: description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentTypeDescriptions_ReturnsFalse(string name, string type, string description1, string description2)
  => CanMerge_False([
    MakeField(name, type, typeDescription: description1),
    MakeField(name, type, typeDescription: description2)],
    description1 == description2);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsOneTypeDescription_ReturnsExpected(string name, string type, string description)
    => Merge_Expected(
      [MakeField(name, type), MakeField(name, type, typeDescription: description)],
      MakeField(name, type, typeDescription: description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameTypeDescription_ReturnsExpected(string name, string type, string description)
    => Merge_Expected(
      [MakeField(name, type, typeDescription: description), MakeField(name, type, typeDescription: description)],
      MakeField(name, type, typeDescription: description));

  internal abstract FieldsMerger<TField, TReference> MergerField { get; }
  internal override GroupsMerger<TField> MergerGroups => MergerField;

  protected abstract TField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "");
  protected override TField MakeAliased(string name, string[] aliases, string description = "")
    => MakeField(name, name, description, description) with { Aliases = aliases };
}

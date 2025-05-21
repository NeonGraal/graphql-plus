using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public abstract class TestObjectFieldMerger<TObjField, TObjBase>
  : TestAliasedMerger<TObjField>
  where TObjField : IGqlpObjField
  where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameModifers_ReturnsGood(string input)
    => CanMerge_Good([MakeFieldModifiers(input), MakeFieldModifiers(input)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentModifers_ReturnsErrors(string input)
    => CanMerge_Errors([MakeFieldModifiers(input), MakeDescribed(input)]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [MakeFieldModifiers(input), MakeFieldModifiers(input)],
      MakeFieldModifiers(input));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameType_ReturnsGood(string name, string type)
  => CanMerge_Good([MakeField(name, type), MakeField(name, type)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentTypes_ReturnsErrors(string name, string type1, string type2)
    => this
      .SkipIf(type1 == type2)
      .CanMerge_Errors(
        MakeField(name, type1),
        MakeField(name, type2));

  [Theory, RepeatData]
  public void Merge_TwoAstsSameType_ReturnsExpected(string name, string type)
    => Merge_Expected(
      [MakeField(name, type), MakeField(name, type)],
      MakeField(name, type));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneTypeDescription_ReturnsGood(string name, string type, string description)
  => CanMerge_Good([MakeField(name, type), MakeField(name, type, typeDescription: description)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameTypeDescription_ReturnsGood(string name, string type, string description)
  => CanMerge_Good(
      MakeField(name, type, typeDescription: description),
      MakeField(name, type, typeDescription: description));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentTypeDescriptions_ReturnsGood(string name, string type, string description1, string description2)
  => this
      .SkipIf(description1 == description2)
      .CanMerge_Good(
        MakeField(name, type, typeDescription: description1),
        MakeField(name, type, typeDescription: description2));

  [Theory, RepeatData]
  public void Merge_TwoAstsOneTypeDescription_ReturnsExpected(string name, string type, string description)
    => Merge_Expected(
      [MakeField(name, type), MakeField(name, type, typeDescription: description)],
      MakeField(name, type, typeDescription: description));

  [Theory, RepeatData]
  public void Merge_TwoAstsSameTypeDescription_ReturnsExpected(string name, string type, string description)
    => Merge_Expected(
      [MakeField(name, type, typeDescription: description), MakeField(name, type, typeDescription: description)],
      MakeField(name, type, typeDescription: description + " " + description));

  internal abstract AstObjectFieldsMerger<TObjField> MergerField { get; }
  internal override GroupsMerger<TObjField> MergerGroups => MergerField;

  protected abstract TObjField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "");
  protected abstract TObjField MakeFieldModifiers(string name);
}

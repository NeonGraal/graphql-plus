using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
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
      .SkipEqual(type1, type2)
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
      .SkipEqual(description1, description2)
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

  [Theory, RepeatData]
  public void CanMerge_TwoAstsEnum_ReturnsGood(string name, string type, string value)
    => CanMerge_Good(
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsEnumOneDescription_ReturnsGood(string name, string type, string description, string value)
    => CanMerge_Good(
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value, description));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsEnumSameDescription_ReturnsGood(string name, string type, string description, string value)
    => CanMerge_Good(
      MakeFieldEnum(name, type, value, description),
      MakeFieldEnum(name, type, value, description));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsEnumDiffDescription_ReturnsGood(string name, string type, string description1, string description2, string value)
    => this
      .SkipEqual(description1, description2)
      .CanMerge_Good(
        MakeFieldEnum(name, type, value, description1),
        MakeFieldEnum(name, type, value, description2));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentEnums_ReturnsErrors(string name, string type, string value1, string value2)
    => this
      .SkipEqual(value1, value2)
      .CanMerge_Errors(
        MakeFieldEnum(name, type, value1),
        MakeFieldEnum(name, type, value2));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneEnum_ReturnsErrors(string name, string type, string value)
    => CanMerge_Errors(
      MakeField(name, type),
      MakeFieldEnum(name, type, value));

  [Theory, RepeatData]
  public void Merge_TwoAstsEnum_ReturnsExpected(string name, string type, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value)],
      MakeFieldEnum(name, type, value));

  [Theory, RepeatData]
  public void Merge_TwoAstsEnumOneDescription_ReturnsExpected(string name, string type, string description, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value, description)],
      MakeFieldEnum(name, type, value, description));

  [Theory, RepeatData]
  public void Merge_TwoAstsEnumSameDescription_ReturnsExpected(string name, string type, string description, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value, description),
      MakeFieldEnum(name, type, value, description)],
      MakeFieldEnum(name, type, value, description + " " + description));

  [Theory, RepeatData]
  public void Merge_TwoAstsEnumOneAlias_ReturnsExpected(string name, string type, string alias, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value, aliases: [alias])],
      MakeFieldEnum(name, type, value, aliases: [alias]));

  [Theory, RepeatData]
  public void Merge_TwoAstsEnumTwoAlias_ReturnsExpected(string name, string type, string alias1, string alias2, string value)
    => this
    .SkipEqual(alias1, alias2)
    .Merge_Expected(
      [MakeFieldEnum(name, type, value, aliases :[alias1]),
        MakeFieldEnum(name, type, value, aliases :[alias2])],
      MakeFieldEnum(name, type, value, aliases: [alias1, alias2]));

  internal abstract AstObjectFieldsMerger<TObjField> MergerField { get; }
  internal override GroupsMerger<TObjField> MergerGroups => MergerField;

  protected override TObjField MakeAliased(string name, string[] aliases, string description = "")
    => MakeField(name, name, description, aliases: aliases);

  protected abstract TObjField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "", string[]? aliases = null);
  protected abstract TObjField MakeFieldModifiers(string name);
  protected abstract TObjField MakeFieldEnum(string name, string enumType, string enumLabel, string fieldDescription = "", string typeDescription = "", string[]? aliases = null);
}

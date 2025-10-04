using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeObjAltsTests(
  ITestOutputHelper outputHelper
) : TestDescriptionsMerger<IGqlpObjAlt>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameModifers_ReturnsGood(string input)
    => CanMerge_Good([
      CheckAlternates.MakeAlternate(input, true),
      CheckAlternates.MakeAlternate(input, true)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentModifers_ReturnsErrors(string input)
    => CanMerge_Errors([
      CheckAlternates.MakeAlternate(input, true),
      MakeDescribed(input)]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [CheckAlternates.MakeAlternate(input, true), CheckAlternates.MakeAlternate(input, true)],
      CheckAlternates.MakeAlternate(input, true));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameEnums_ReturnsGood(string type, string label)
    => CanMerge_Good([
      CheckAlternates.MakeAltEnum(type, label),
      CheckAlternates.MakeAltEnum(type, label)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentEnums_ReturnsGood(string type, string label)
    => CanMerge_Good([
      CheckAlternates.MakeAltEnum(type, label),
      MakeDescribed(type)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentLabels_ReturnsGood(string type, string label1, string label2)
    => this
    .SkipEqual(label1, label2)
    .CanMerge_Good([
      CheckAlternates.MakeAltEnum(type, label1),
      CheckAlternates.MakeAltEnum(type, label2)]);

  [Theory, RepeatData]
  public void Merge_TwoAstsSameEnum_ReturnsExpected(string type, string label)
    => Merge_Expected(
      [CheckAlternates.MakeAltEnum(type, label), CheckAlternates.MakeAltEnum(type, label)],
      CheckAlternates.MakeAltEnum(type, label));

  [Theory, RepeatData]
  public void Merge_TwoAstsDifferentLabels_ReturnsExpected(string type, string label1, string label2)
    => this
    .SkipEqual(label1, label2)
    .Merge_Expected(
      [CheckAlternates.MakeAltEnum(type, label1), CheckAlternates.MakeAltEnum(type, label2)],
      CheckAlternates.MakeAltEnum(type, label1), CheckAlternates.MakeAltEnum(type, label2));

  internal CheckAlternatesMerger CheckAlternates { get; } = new();
  internal MergeObjAlts MergerAlternate { get; } = new(outputHelper.ToLoggerFactory());
  internal override GroupsMerger<IGqlpObjAlt> MergerGroups => MergerAlternate;

  protected override IGqlpObjAlt MakeDescribed(string name, string description = "")
    => CheckAlternates.MakeAlternate(name, false, description);
}

internal sealed class CheckAlternatesMerger
  : ICheckAlternatesMerger
{
  public IGqlpObjAlt MakeAltEnum(string type, string label)
    => new ObjAltAst(AstNulls.At, type, "") {
      EnumValue = new EnumValueAst(AstNulls.At, type, label)
    };
  public IGqlpObjAlt MakeAlternate(string input, bool withModifiers = false, string description = "")
    => new ObjAltAst(AstNulls.At, input, description) {
      Modifiers = withModifiers ? TestMods() : []
    };
}

internal interface ICheckAlternatesMerger
{
  IGqlpObjAlt MakeAlternate(string input, bool withModifiers = false, string description = "");
  IGqlpObjAlt MakeAltEnum(string type, string label);
}

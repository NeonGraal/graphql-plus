using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Merging.Objects;

namespace GqlPlus.Verifier.Merging;

public abstract class TestObjectFields<TField, TRef>
  : TestAliased<TField>
  where TField : AstObjectField<TRef>, IAstDescribed
  where TRef : AstReference<TRef>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameModifers_ReturnsGood(string input)
    => CanMerge_Good([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentModifers_ReturnsErrors(string input)
    => CanMerge_Errors([MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameModifers_ReturnsExpected(string input)
    => Merge_Expected(
      [MakeDescribed(input) with { Modifiers = TestMods() }, MakeDescribed(input) with { Modifiers = TestMods() }],
      MakeDescribed(input) with { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameType_ReturnsGood(string name, string type)
  => CanMerge_Good([MakeField(name, type), MakeField(name, type)]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentTypes_ReturnsErrors(string name, string type1, string type2)
    => this
      .SkipIf(type1 == type2)
      .CanMerge_Errors(
        MakeField(name, type1),
        MakeField(name, type2));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsSameType_ReturnsExpected(string name, string type)
    => Merge_Expected(
      [MakeField(name, type), MakeField(name, type)],
      MakeField(name, type));

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneTypeDescription_ReturnsGood(string name, string type, string description)
  => CanMerge_Good([MakeField(name, type), MakeField(name, type, typeDescription: description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameTypeDescription_ReturnsGood(string name, string type, string description)
  => CanMerge_Good(
      MakeField(name, type, typeDescription: description),
      MakeField(name, type, typeDescription: description));

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentTypeDescriptions_ReturnsErrors(string name, string type, string description1, string description2)
  => this
      .SkipIf(description1 == description2)
      .CanMerge_Errors(
        MakeField(name, type, typeDescription: description1),
        MakeField(name, type, typeDescription: description2));

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

  internal abstract AstObjectFieldsMerger<TField, TRef> MergerField { get; }
  internal override GroupsMerger<TField> MergerGroups => MergerField;

  protected abstract TField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "");
  protected override TField MakeAliased(string name, string[] aliases, string description = "")
    => MakeField(name, name, description, description) with { Aliases = aliases };
}

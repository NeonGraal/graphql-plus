using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Schema.Objects;

public class MergeOutputFieldsTests
  : TestObjectFields<IGqlpOutputField, IGqlpOutputBase>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsParamsCantMerge_ReturnsErrors(string name, string type, string[] parameters)
    => this
      .SkipUnless(parameters)
      .CanMergeReturnsError(_parameters)
      .CanMerge_Errors(
        MakeFieldParams(name, type, parameters),
        MakeField(name, type));

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
      .SkipIf(description1 == description2)
      .CanMerge_Good(
        MakeFieldEnum(name, type, value, description1),
        MakeFieldEnum(name, type, value, description2));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentEnums_ReturnsErrors(string name, string type, string value1, string value2)
    => this
      .SkipIf(value1 == value2)
      .CanMerge_Errors(
        MakeFieldEnum(name, type, value1),
        MakeFieldEnum(name, type, value2));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneEnum_ReturnsErrors(string name, string type, string value)
    => CanMerge_Errors(
      MakeField(name, type),
      MakeFieldEnum(name, type, value));

  [Theory, RepeatData]
  public void Merge_TwoAstsWithParams_CallsParamsMerge(string name, string type, string[] parameters)
    => Merge_Expected(
        [MakeFieldParams(name, type, parameters),
          MakeFieldParams(name, type, parameters)],
        MakeFieldParams(name, type, parameters.Concat(parameters)))
      .MergeCalled(_parameters);

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
      MakeFieldEnum(name, type, value) with { Aliases = [alias] }],
      MakeFieldEnum(name, type, value) with { Aliases = [alias] });

  [Theory, RepeatData]
  public void Merge_TwoAstsEnumTwoAlias_ReturnsExpected(string name, string type, string alias1, string alias2, string value)
    => this
    .SkipIf(alias1 == alias2)
    .Merge_Expected(
      [MakeFieldEnum(name, type, value) with { Aliases = [alias1] },
        MakeFieldEnum(name, type, value) with { Aliases = [alias2] }],
      MakeFieldEnum(name, type, value) with { Aliases = [alias1, alias2] });

  private readonly MergeOutputFields _merger;
  private readonly IMerge<IGqlpInputParam> _parameters;

  public MergeOutputFieldsTests(ITestOutputHelper outputHelper)
  {
    _parameters = Merger<IGqlpInputParam>();
    _merger = new(outputHelper.ToLoggerFactory(), _parameters);
  }

  internal override AstObjectFieldsMerger<IGqlpOutputField> MergerField => _merger;

  protected override IGqlpOutputField MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new OutputFieldAst(AstNulls.At, name, fieldDescription, new OutputBaseAst(AstNulls.At, type, typeDescription));
  private static OutputFieldAst MakeFieldParams(string name, string type, IEnumerable<string> parameters)
    => new(AstNulls.At, name, new OutputBaseAst(AstNulls.At, type)) {
      Params = parameters.ThrowIfNull().Params()
    };
  private static OutputFieldAst MakeFieldEnum(string name, string type, string enumLabel, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new OutputBaseAst(AstNulls.At, type, typeDescription) { EnumLabel = enumLabel });
  protected override IGqlpOutputField MakeFieldModifiers(string name)
    => new OutputFieldAst(AstNulls.At, name, new OutputBaseAst(AstNulls.At, name)) {
      Modifiers = TestMods()
    };
  protected override IGqlpOutputField MakeAliased(string name, string[] aliases, string description = "")
    => new OutputFieldAst(AstNulls.At, name, description, new OutputBaseAst(AstNulls.At, name, description)) {
      Aliases = aliases
    };
}

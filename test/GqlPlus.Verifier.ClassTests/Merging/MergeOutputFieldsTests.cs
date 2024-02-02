using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeOutputFieldsTests
  : TestFields<OutputFieldAst, OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsParametersCantMerge_ReturnsFalse(string name, string type, string[] parameters)
  {
    if (parameters.Length < 2) {
      return;
    }

    _parameters.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([MakeField(name, type) with { Parameters = parameters.Parameters() }, MakeField(name, type)]);
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsEnum_ReturnsTrue(string name, string type, string value)
    => CanMerge_True([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsEnumOneDescription_ReturnsTrue(string name, string type, string description, string value)
    => CanMerge_True([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsEnumSameDescription_ReturnsTrue(string name, string type, string description, string value)
    => CanMerge_True([
      MakeFieldEnum(name, type, value, description),
      MakeFieldEnum(name, type, value, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsEnumDiffDescription_ReturnsFalse(string name, string type, string description1, string description2, string value)
    => CanMerge_False([
      MakeFieldEnum(name, type, value, description1),
      MakeFieldEnum(name, type, value, description2)],
      description1 == description2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentEnums_ReturnsFalse(string name, string type, string value1, string value2)
  => CanMerge_False([
      MakeFieldEnum(name, type, value1),
    MakeFieldEnum(name, type, value2)],
      value1 == value2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneEnum_ReturnsFalse(string name, string type, string value)
    => CanMerge_False([MakeField(name, type), MakeFieldEnum(name, type, value)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsWithParameters_CallsParametersMerge(string name, string type, string[] parameters)
  {
    Merge_Expected([
      MakeField(name, type) with { Parameters = parameters.Parameters() },
      MakeField(name, type) with { Parameters = parameters.Parameters() }],
      MakeField(name, type) with { Parameters = parameters.Concat(parameters).Parameters() });

    _parameters.ReceivedWithAnyArgs(1).Merge([]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsEnum_ReturnsExpected(string name, string type, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value)],
      MakeFieldEnum(name, type, value));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsEnumOneDescription_ReturnsExpected(string name, string type, string description, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value, description)],
      MakeFieldEnum(name, type, value, description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsEnumSameDescription_ReturnsExpected(string name, string type, string description, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value, description),
      MakeFieldEnum(name, type, value, description)],
      MakeFieldEnum(name, type, value, description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsEnumOneAlias_ReturnsExpected(string name, string type, string alias, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value) with { Aliases = [alias] }],
      MakeFieldEnum(name, type, value) with { Aliases = [alias] });

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsEnumTwoAlias_ReturnsExpected(string name, string type, string alias1, string alias2, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value) with { Aliases = [alias1] },
      MakeFieldEnum(name, type, value) with { Aliases = [alias2] }],
      alias1 == alias2,
      MakeFieldEnum(name, type, value) with { Aliases = [alias1, alias2] });

  private readonly MergeOutputFields _merger;
  private readonly IMerge<ParameterAst> _parameters;

  public MergeOutputFieldsTests()
  {
    _parameters = Merger<ParameterAst>();
    _merger = new(_parameters);
  }

  internal override FieldsMerger<OutputFieldAst, OutputReferenceAst> MergerField => _merger;

  protected override OutputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));

  private static OutputFieldAst MakeFieldEnum(string name, string type, string enumValue, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription) { EnumValue = enumValue });
}

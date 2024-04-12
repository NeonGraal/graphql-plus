using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeOutputFieldsTests
  : TestFields<OutputFieldAst, OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsParametersCantMerge_ReturnsErrors(string name, string type, string[] parameters)
  {
    if (parameters is null || parameters.Length < 2) {
      return;
    }

    _parameters.CanMerge([]).ReturnsForAnyArgs(ErrorMessages);

    CanMerge_Errors([MakeField(name, type) with { Parameters = parameters.Parameters() }, MakeField(name, type)]);
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsEnum_ReturnsGood(string name, string type, string value)
    => CanMerge_Good([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsEnumOneDescription_ReturnsGood(string name, string type, string description, string value)
    => CanMerge_Good([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value, description)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsEnumSameDescription_ReturnsGood(string name, string type, string description, string value)
    => CanMerge_Good([
      MakeFieldEnum(name, type, value, description),
      MakeFieldEnum(name, type, value, description)]);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsEnumDiffDescription_ReturnsErrors(string name, string type, string description1, string description2, string value)
    => CanMerge_Errors([
      MakeFieldEnum(name, type, value, description1),
      MakeFieldEnum(name, type, value, description2)],
      description1 == description2);

  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentEnums_ReturnsErrors(string name, string type, string value1, string value2)
  => CanMerge_Errors([
      MakeFieldEnum(name, type, value1),
      MakeFieldEnum(name, type, value2)],
      value1 == value2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsOneEnum_ReturnsErrors(string name, string type, string value)
    => CanMerge_Errors([MakeField(name, type), MakeFieldEnum(name, type, value)]);

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsWithParameters_CallsParametersMerge(string name, string type, string[] parameters)
  {
    Merge_Expected([
      MakeField(name, type) with { Parameters = parameters.Parameters() },
      MakeField(name, type) with { Parameters = parameters.Parameters() }],
      MakeField(name, type) with { Parameters = parameters.Concat(parameters).Parameters() });

    _parameters.ReceivedWithAnyArgs(1).Merge([]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsEnum_ReturnsExpected(string name, string type, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value)],
      MakeFieldEnum(name, type, value));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsEnumOneDescription_ReturnsExpected(string name, string type, string description, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value, description)],
      MakeFieldEnum(name, type, value, description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsEnumSameDescription_ReturnsExpected(string name, string type, string description, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value, description),
      MakeFieldEnum(name, type, value, description)],
      MakeFieldEnum(name, type, value, description));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsEnumOneAlias_ReturnsExpected(string name, string type, string alias, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value),
      MakeFieldEnum(name, type, value) with { Aliases = [alias] }],
      MakeFieldEnum(name, type, value) with { Aliases = [alias] });

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_TwoAstsEnumTwoAlias_ReturnsExpected(string name, string type, string alias1, string alias2, string value)
    => Merge_Expected([
      MakeFieldEnum(name, type, value) with { Aliases = [alias1] },
      MakeFieldEnum(name, type, value) with { Aliases = [alias2] }],
      alias1 == alias2,
      MakeFieldEnum(name, type, value) with { Aliases = [alias1, alias2] });

  private readonly MergeOutputFields _merger;
  private readonly IMerge<ParameterAst> _parameters;

  public MergeOutputFieldsTests(ITestOutputHelper outputHelper)
  {
    _parameters = Merger<ParameterAst>();
    _merger = new(outputHelper.ToLoggerFactory(), _parameters);
  }

  internal override FieldsMerger<OutputFieldAst, OutputReferenceAst> MergerField => _merger;

  protected override OutputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));

  private static OutputFieldAst MakeFieldEnum(string name, string type, string enumValue, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription) { EnumValue = enumValue });
}

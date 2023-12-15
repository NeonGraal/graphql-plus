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
  public void CanMerge_TwoItemsSameEnum_ReturnsTrue(string name, string type, string value)
    => CanMerge_True([
      MakeField(name, type) with { EnumValue = value },
      MakeField(name, type) with { EnumValue = value }]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentEnums_ReturnsFalse(string name, string type, string value1, string value2)
    => CanMerge_False([
      MakeField(name, type) with { EnumValue = value1 },
      MakeField(name, type) with { EnumValue = value2 }],
      value1 == value2);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneEnum_ReturnsFalse(string name, string type, string value)
    => CanMerge_False([MakeField(name, type) with { EnumValue = value }, MakeField(name, type)]);

  private readonly MergeOutputFields _merger;
  private readonly IMerge<ParameterAst> _parameters;

  public MergeOutputFieldsTests()
  {
    _parameters = Substitute.For<IMerge<ParameterAst>>();
    _parameters.CanMerge([]).ReturnsForAnyArgs(true);

    _merger = new(_parameters);
  }

  protected override FieldsMerger<OutputFieldAst, OutputReferenceAst> MergerField => _merger;

  protected override OutputFieldAst MakeField(string name, string type, string fieldDescription = "", string typeDescription = "")
    => new(AstNulls.At, name, fieldDescription, new(AstNulls.At, type, typeDescription));
}

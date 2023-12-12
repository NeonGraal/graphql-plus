using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeOutputFieldsTests
  : TestFields<OutputFieldAst, OutputReferenceAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsParametersCantMerge_ReturnsFalse(string name, string type)
  {
    var items = new[] { MakeField(name, type), MakeField(name, type) };
    _parameters.CanMerge([]).ReturnsForAnyArgs(false);

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameEnum_ReturnsTrue(string name, string type, string value)
  {
    var items = new[] { MakeField(name, type) with { EnumValue = value }, MakeField(name, type) with { EnumValue = value } };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentEnums_ReturnsFalse(string name, string type, string value1, string value2)
  {
    if (value1 == value2) {
      return;
    }

    var items = new[] { MakeField(name, type) with { EnumValue = value1 }, MakeField(name, type) with { EnumValue = value2 } };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsOneEnum_ReturnsFalse(string name, string type, string value)
  {
    var items = new[] { MakeField(name, type) with { EnumValue = value }, MakeField(name, type) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

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

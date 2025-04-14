using GqlPlus.Ast;

namespace GqlPlus.Merging.Schema;

public class MergeConstantsTests
  : TestAbbreviatedMerger<IGqlpConstant>
{
  [Theory, RepeatData]
  public void Merge_TwoAstsBothValues_ReturnsExpected(string valueA, string valueB)
  {
    IGqlpConstant astA = MakeValue(valueA);
    IGqlpConstant astB = MakeValue(valueB);

    Merge_Expected([astA, astB], astB);
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsValueAndList_ReturnsExpected(string valueA, string[] listB)
  {
    this.SkipIf(listB.Contains(valueA));

    IGqlpConstant astA = MakeValue(valueA);
    IGqlpConstant astB = MakeList(listB);

    Merge_Expected([astA, astB], MakeList([valueA, .. listB]));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsValueAndObject_ReturnsExpected(string valueA, string[] fieldsB)
  {
    IGqlpConstant astA = MakeValue(valueA);
    IGqlpConstant astB = MakeObject(fieldsB);

    Merge_Expected([astA, astB], MakeObject(fieldsB));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsListAndValue_ReturnsExpected(string[] listA, string valueB)
  {
    this.SkipIf(listA.Contains(valueB));

    IGqlpConstant astA = MakeList(listA);
    IGqlpConstant astB = MakeValue(valueB);

    Merge_Expected([astA, astB], MakeList([.. listA, valueB]));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsBothLists_ReturnsExpected(string[] listA, string[] listB)
  {
    IGqlpConstant astA = MakeList(listA);
    IGqlpConstant astB = MakeList(listB);

    Merge_Expected([astA, astB], MakeList([.. listA, .. listB]));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsListAndObject_ReturnsExpected(string[] listA, string[] fieldsB)
  {
    ConstantAst astA = MakeList(listA);
    IGqlpConstant astB = MakeObject(fieldsB);
    IGqlpConstant expected = astA with { Values = [.. astA.Values, astB] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsObjectAndValue_ReturnsExpected(string[] fieldsA, string valueB)
  {
    IGqlpConstant astA = MakeObject(fieldsA);
    IGqlpConstant astB = MakeValue(valueB);

    Merge_Expected([astA, astB], MakeValue(valueB));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsObjectAndList_ReturnsExpected(string[] fieldsA, string[] listB)
  {
    IGqlpConstant astA = MakeObject(fieldsA);
    ConstantAst astB = MakeList(listB);
    ConstantAst expected = astB with { Values = [astA, .. astB.Values] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsBothObjects_ReturnsExpected(string[] fieldsA, string[] fieldsB)
  {
    IGqlpConstant astA = MakeObject(fieldsA);
    IGqlpConstant astB = MakeObject(fieldsB);

    Merge_Expected([astA, astB], MakeObject(fieldsA.Concat(fieldsB).Distinct()));
  }

  private readonly MergeConstants _merger = new();

  protected override IMerge<IGqlpConstant> MergerBase => _merger;

  protected override IGqlpConstant MakeAst(string input)
    => new ConstantAst(new FieldKeyAst(AstNulls.At, input));

  private IGqlpConstant MakeValue(string value)
    => new ConstantAst(new FieldKeyAst(AstNulls.At, value));

  private ConstantAst MakeList(IEnumerable<string> list)
    => new(AstNulls.At, [.. list.Distinct().Select(MakeValue)]);

  private ConstantAst MakeObject(IEnumerable<string> fields)
    => new(AstNulls.At, fields.ToObject(v => new FieldKeyAst(AstNulls.At, v), MakeValue));
}

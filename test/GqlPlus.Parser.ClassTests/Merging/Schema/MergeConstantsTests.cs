namespace GqlPlus.Merging.Schema;

public class MergeConstantsTests
  : TestAbbreviatedMerger<IAstConstant>
{
  [Theory, RepeatData]
  public void Merge_TwoAstsBothValues_ReturnsExpected(string valueA, string valueB)
  {
    IAstConstant astA = MakeValue(valueA);
    IAstConstant astB = MakeValue(valueB);

    Merge_Expected([astA, astB], astB);
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsValueAndList_ReturnsExpected(string valueA, string[] listB)
  {
    this.SkipIf(listB.Contains(valueA));

    IAstConstant astA = MakeValue(valueA);
    IAstConstant astB = MakeList(listB);

    Merge_Expected([astA, astB], MakeList([valueA, .. listB]));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsValueAndObject_ReturnsExpected(string valueA, string[] fieldsB)
  {
    IAstConstant astA = MakeValue(valueA);
    IAstConstant astB = MakeObject(fieldsB);

    Merge_Expected([astA, astB], MakeObject(fieldsB));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsListAndValue_ReturnsExpected(string[] listA, string valueB)
  {
    this.SkipIf(listA.Contains(valueB));

    IAstConstant astA = MakeList(listA);
    IAstConstant astB = MakeValue(valueB);

    Merge_Expected([astA, astB], MakeList([.. listA, valueB]));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsBothLists_ReturnsExpected(string[] listA, string[] listB)
  {
    IAstConstant astA = MakeList(listA);
    IAstConstant astB = MakeList(listB);

    Merge_Expected([astA, astB], MakeList([.. listA, .. listB]));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsListAndObject_ReturnsExpected(string[] listA, string[] fieldsB)
  {
    ConstantAst astA = MakeList(listA);
    IAstConstant astB = MakeObject(fieldsB);
    IAstConstant expected = astA with { Values = [.. astA.Values, astB] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsObjectAndValue_ReturnsExpected(string[] fieldsA, string valueB)
  {
    IAstConstant astA = MakeObject(fieldsA);
    IAstConstant astB = MakeValue(valueB);

    Merge_Expected([astA, astB], MakeValue(valueB));
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsObjectAndList_ReturnsExpected(string[] fieldsA, string[] listB)
  {
    IAstConstant astA = MakeObject(fieldsA);
    ConstantAst astB = MakeList(listB);
    ConstantAst expected = astB with { Values = [astA, .. astB.Values] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData]
  public void Merge_TwoAstsBothObjects_ReturnsExpected(string[] fieldsA, string[] fieldsB)
  {
    IAstConstant astA = MakeObject(fieldsA);
    IAstConstant astB = MakeObject(fieldsB);

    Merge_Expected([astA, astB], MakeObject(fieldsA.Concat(fieldsB).Distinct()));
  }

  private readonly MergeConstants _merger = new();

  protected override IMerge<IAstConstant> MergerBase => _merger;

  protected override IAstConstant MakeAst(string input)
    => new ConstantAst(new FieldKeyAst(AstNulls.At, input));

  private IAstConstant MakeValue(string value)
    => new ConstantAst(new FieldKeyAst(AstNulls.At, value));

  private ConstantAst MakeList(IEnumerable<string> list)
    => new(AstNulls.At, [.. list.Distinct().Select(MakeValue)]);

  private ConstantAst MakeObject(IEnumerable<string> fields)
    => new(AstNulls.At, fields.ToObject(v => new FieldKeyAst(AstNulls.At, v), MakeValue));
}

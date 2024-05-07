using GqlPlus.Ast;

namespace GqlPlus.Merging;

public class MergeConstantsTests
  : TestAbbreviated<ConstantAst>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsBothValues_ReturnsExpected(string valueA, string valueB)
  {
    ConstantAst astA = MakeValue(valueA);
    ConstantAst astB = MakeValue(valueB);

    Merge_Expected([astA, astB], astB);
  }

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_TwoAstsValueAndList_ReturnsExpected(string valueA, string[] listB)
  {
    this.SkipIf(listB.Contains(valueA));

    ConstantAst astA = MakeValue(valueA);
    ConstantAst astB = MakeList(listB);

    Merge_Expected([astA, astB], MakeList([valueA, .. listB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsValueAndObject_ReturnsExpected(string valueA, string[] fieldsB)
  {
    ConstantAst astA = MakeValue(valueA);
    ConstantAst astB = MakeObject(fieldsB);

    Merge_Expected([astA, astB], MakeObject(fieldsB));
  }

  [SkippableTheory, RepeatData(Repeats)]
  public void Merge_TwoAstsListAndValue_ReturnsExpected(string[] listA, string valueB)
  {
    this.SkipIf(listA.Contains(valueB));

    ConstantAst astA = MakeList(listA);
    ConstantAst astB = MakeValue(valueB);

    Merge_Expected([astA, astB], MakeList([.. listA, valueB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsBothLists_ReturnsExpected(string[] listA, string[] listB)
  {
    ConstantAst astA = MakeList(listA);
    ConstantAst astB = MakeList(listB);

    Merge_Expected([astA, astB], MakeList([.. listA, .. listB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsListAndObject_ReturnsExpected(string[] listA, string[] fieldsB)
  {
    ConstantAst astA = MakeList(listA);
    ConstantAst astB = MakeObject(fieldsB);
    ConstantAst expected = astA with { Values = [.. astA.Values, astB] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsObjectAndValue_ReturnsExpected(string[] fieldsA, string valueB)
  {
    ConstantAst astA = MakeObject(fieldsA);
    ConstantAst astB = MakeValue(valueB);

    Merge_Expected([astA, astB], MakeValue(valueB));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsObjectAndList_ReturnsExpected(string[] fieldsA, string[] listB)
  {
    ConstantAst astA = MakeObject(fieldsA);
    ConstantAst astB = MakeList(listB);
    ConstantAst expected = astB with { Values = [astA, .. astB.Values] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsBothObjects_ReturnsExpected(string[] fieldsA, string[] fieldsB)
  {
    ConstantAst astA = MakeObject(fieldsA);
    ConstantAst astB = MakeObject(fieldsB);

    Merge_Expected([astA, astB], MakeObject(fieldsA.Concat(fieldsB).Distinct()));
  }

  private readonly MergeConstants _merger = new();

  protected override IMerge<ConstantAst> MergerBase => _merger;

  protected override ConstantAst MakeAst(string input)
    => new FieldKeyAst(AstNulls.At, input);

  private ConstantAst MakeValue(string value)
    => new FieldKeyAst(AstNulls.At, value);

  private ConstantAst MakeList(IEnumerable<string> list)
    => new(AstNulls.At, [.. list.Distinct().Select(MakeValue)]);

  private ConstantAst MakeObject(IEnumerable<string> fields)
    => new(AstNulls.At, fields.ToObject(v => new(AstNulls.At, v), MakeValue));
}

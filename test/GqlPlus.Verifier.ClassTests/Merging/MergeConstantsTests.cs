using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public class MergeConstantsTests
  : TestAbbreviated<ConstantAst>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsBothValues_ReturnsExpected(string valueA, string valueB)
  {
    var astA = MakeValue(valueA);
    var astB = MakeValue(valueB);

    Merge_Expected([astA, astB], astB);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsValueAndList_ReturnsExpected(string valueA, string[] listB)
  {
    var astA = MakeValue(valueA);
    var astB = MakeList(listB);

    Merge_Expected([astA, astB], listB.Contains(valueA), MakeList([valueA, .. listB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsValueAndObject_ReturnsExpected(string valueA, string[] fieldsB)
  {
    var astA = MakeValue(valueA);
    var astB = MakeObject(fieldsB);

    Merge_Expected([astA, astB], MakeObject(fieldsB));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsListAndValue_ReturnsExpected(string[] listA, string valueB)
  {
    var astA = MakeList(listA);
    var astB = MakeValue(valueB);

    Merge_Expected([astA, astB], listA.Contains(valueB), MakeList([.. listA, valueB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsBothLists_ReturnsExpected(string[] listA, string[] listB)
  {
    var astA = MakeList(listA);
    var astB = MakeList(listB);

    Merge_Expected([astA, astB], MakeList([.. listA, .. listB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsListAndObject_ReturnsExpected(string[] listA, string[] fieldsB)
  {
    var astA = MakeList(listA);
    var astB = MakeObject(fieldsB);
    var expected = astA with { Values = [.. astA.Values, astB] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsObjectAndValue_ReturnsExpected(string[] fieldsA, string valueB)
  {
    var astA = MakeObject(fieldsA);
    var astB = MakeValue(valueB);

    Merge_Expected([astA, astB], MakeValue(valueB));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsObjectAndList_ReturnsExpected(string[] fieldsA, string[] listB)
  {
    var astA = MakeObject(fieldsA);
    var astB = MakeList(listB);
    var expected = astB with { Values = [astA, .. astB.Values] };

    Merge_Expected([astA, astB], expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsBothObjects_ReturnsExpected(string[] fieldsA, string[] fieldsB)
  {
    var astA = MakeObject(fieldsA);
    var astB = MakeObject(fieldsB);

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

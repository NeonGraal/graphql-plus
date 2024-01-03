using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public class MergeConstantsTests
  : TestBase<ConstantAst>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsBothValues_ReturnsExpected(string valueA, string valueB)
  {
    var itemA = MakeValue(valueA);
    var itemB = MakeValue(valueB);

    Merge_Expected([itemA, itemB], itemB);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsValueAndList_ReturnsExpected(string valueA, string[] listB)
  {
    var itemA = MakeValue(valueA);
    var itemB = MakeList(listB);

    Merge_Expected([itemA, itemB], listB.Contains(valueA), MakeList([valueA, .. listB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsValueAndObject_ReturnsExpected(string valueA, string[] fieldsB)
  {
    var itemA = MakeValue(valueA);
    var itemB = MakeObject(fieldsB);

    Merge_Expected([itemA, itemB], MakeObject(fieldsB));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsListAndValue_ReturnsExpected(string[] listA, string valueB)
  {
    var itemA = MakeList(listA);
    var itemB = MakeValue(valueB);

    Merge_Expected([itemA, itemB], listA.Contains(valueB), MakeList([.. listA, valueB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsBothLists_ReturnsExpected(string[] listA, string[] listB)
  {
    var itemA = MakeList(listA);
    var itemB = MakeList(listB);

    Merge_Expected([itemA, itemB], MakeList([.. listA, .. listB]));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsListAndObject_ReturnsExpected(string[] listA, string[] fieldsB)
  {
    var itemA = MakeList(listA);
    var itemB = MakeObject(fieldsB);
    var expected = itemA with { Values = [.. itemA.Values, itemB] };

    Merge_Expected([itemA, itemB], expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsObjectAndValue_ReturnsExpected(string[] fieldsA, string valueB)
  {
    var itemA = MakeObject(fieldsA);
    var itemB = MakeValue(valueB);

    Merge_Expected([itemA, itemB], MakeValue(valueB));
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsObjectAndList_ReturnsExpected(string[] fieldsA, string[] listB)
  {
    var itemA = MakeObject(fieldsA);
    var itemB = MakeList(listB);
    var expected = itemB with { Values = [itemA, .. itemB.Values] };

    Merge_Expected([itemA, itemB], expected);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsBothObjects_ReturnsExpected(string[] fieldsA, string[] fieldsB)
  {
    var itemA = MakeObject(fieldsA);
    var itemB = MakeObject(fieldsB);

    Merge_Expected([itemA, itemB], MakeObject(fieldsA.Concat(fieldsB).Distinct()));
  }

  private readonly MergeConstants _merger = new();

  protected override IMerge<ConstantAst> MergerBase => _merger;

  protected override ConstantAst MakeDistinct(string name)
    => new FieldKeyAst(AstNulls.At, name);

  private ConstantAst MakeValue(string value)
    => new FieldKeyAst(AstNulls.At, value);

  private ConstantAst MakeList(IEnumerable<string> list)
    => new(AstNulls.At, [.. list.Distinct().Select(MakeValue)]);

  private ConstantAst MakeObject(IEnumerable<string> fields)
    => new(AstNulls.At, fields.ToObject(v => new(AstNulls.At, v), MakeValue));
}

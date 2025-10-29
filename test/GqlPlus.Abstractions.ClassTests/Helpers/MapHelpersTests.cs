namespace GqlPlus.Helpers;

public class MapHelpersTests
{
  [Theory, RepeatData]
  public void ToPair_FromInt(int value)
  {
    MapPair<int> pair = value.ToPair(k => $"{k}");

    pair.ShouldSatisfyAllConditions(
      m => m.Key.ShouldBe($"{value}"),
      m => m.Value.ShouldBe(value));
  }

  [Theory, RepeatData]
  public void ToPair_FromDecimal(decimal value, string key)
  {
    MapPair<decimal> pair = value.ToPair(key);

    pair.ShouldSatisfyAllConditions(
      m => m.Key.ShouldBe(key),
      m => m.Value.ShouldBe(value));
  }

  [Theory, RepeatData]
  public void ToPair_FromStringInt(StringInt value)
  {
    MapPair<int> pair = value.ToPair(k => k.Name, k => k.Age);

    pair.ShouldSatisfyAllConditions(
      m => m.Key.ShouldBe(value.Name),
      m => m.Value.ShouldBe(value.Age));
  }

  [Theory, RepeatData]
  public void ToMap_FromStrings(string[] values)
  {
    Map<string> map = values.ToMap(static k => k);

    map.ShouldSatisfyAllConditions(
      m => m.Keys.ShouldBe(values),
      m => m.Values.ShouldBe(values));
  }

  [Theory, RepeatData]
  public void ToMap_FromRecord(StringInt[] values)
  {
    IGrouping<string, StringInt>[] groups = [.. values.GroupBy(v => v.Name)];
    Map<int[]> map = groups.ToMap(static k => k.Key, static v => v.Select(a => a.Age).ToArray());

    map.ShouldSatisfyAllConditions(
      m => m.Keys.ShouldBe(groups.Select(static k => k.Key)),
      m => m.Values.ShouldBe(groups.Select(static v => v.Select(a => a.Age).ToArray())));
  }
}

public record struct StringInt(string Name, int Age);

namespace GqlPlus.Helpers;

public class MapTests
{
  [Theory, RepeatData]
  public void ToMap_FromStrings(string[] values)
  {
    Map<string> map = values.ToMap(static k => k);

    // using AssertionScope scope = new();

    map.Keys.ShouldBe(values);
    map.Values.ShouldBe(values);
  }

  [Theory, RepeatData]
  public void ToMap_FromRecord(StringInt[] values)
  {
    IGrouping<string, StringInt>[] groups = [.. values.GroupBy(v => v.Name)];
    Map<int[]> map = groups.ToMap(static k => k.Key, static v => v.Select(a => a.Age).ToArray());

    // using AssertionScope scope = new();

    map.Keys.ShouldBe(groups.Select(static k => k.Key));
    map.Values.ShouldBe(groups.Select(static v => v.Select(a => a.Age).ToArray()));
  }
}

public record struct StringInt(string Name, int Age);

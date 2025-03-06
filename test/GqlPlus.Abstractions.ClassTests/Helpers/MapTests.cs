namespace GqlPlus.Helpers;

public class MapTests
{
  [Theory, RepeatData]
  public void ToMap_FromStrings(string[] values)
  {
    Map<string> map = values.ToMap(static k => k);

    using AssertionScope scope = new();

    map.Keys.Should().BeEquivalentTo(values);
    map.Values.Should().BeEquivalentTo(values);
  }

  [Theory, RepeatData]
  public void ToMap_FromRecord(StringInt[] values)
  {
    IGrouping<string, StringInt>[] groups = [.. values.GroupBy(v => v.Name)];
    Map<int[]> map = groups.ToMap(static k => k.Key, static v => v.Select(a => a.Age).ToArray());

    using AssertionScope scope = new();

    map.Keys.Should().BeEquivalentTo(groups.Select(static k => k.Key));
    map.Values.Should().BeEquivalentTo(groups.Select(static v => v.Select(a => a.Age).ToArray()));
  }
}

public record struct StringInt(string Name, int Age);

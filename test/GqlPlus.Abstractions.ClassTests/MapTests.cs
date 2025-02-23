namespace GqlPlus;

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
    Map<int> map = values.ToMap(static k => k.Name, static v => v.Age);

    using AssertionScope scope = new();

    map.Keys.Should().BeEquivalentTo(values.Select(static k => k.Name));
    map.Values.Should().BeEquivalentTo(values.Select(static v => v.Age));
  }
}

public record struct StringInt(string Name, int Age);

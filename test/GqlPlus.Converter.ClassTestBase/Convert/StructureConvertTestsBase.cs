namespace GqlPlus.Convert;

public abstract class StructureConvertTestsBase(IConvertTestsBase converters)
  : StructureConvertToTestsBase(converters)
{
  [Theory, RepeatData]
  public void ConvertFrom_List(string[] value)
  {
    string[] input = Expected_List(value);
    Structured expected = AsList(value, AsValue);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_Map(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    string[] input = Expected_Map(value);
    Structured expected = AsMap(value, AsValue);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_ListOfLists(string[][] value)
  {
    string[] input = Expected_ListOfLists(value);
    Structured expected = AsList(value, v => AsList(v, AsValue));

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_MapOfLists(MapPair<string[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    string[] input = Expected_MapOfLists(value);
    Structured expected = AsMap(value, v => AsList(v, AsValue));

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_ListOfMaps(MapPair<string>[][] value)
  {
    Assert.SkipWhen(value is null || value.Any(v => MapDups(v)), "Duplicate Keys in map");

    string[] input = Expected_ListOfMaps(value);
    Structured expected = AsList(value, v => AsMap(v, AsValue));

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_MapOfMaps(MapPair<MapPair<string>[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value) || value.Any(v => MapDups(v.Value)), "Duplicate Keys in map");

    string[] input = Expected_MapOfMaps(value);
    Structured expected = AsMap(value, v => AsMap(v, AsValue));

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_List(string[] value)
  {
    Structured expected = AsList(value, AsValue);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_Map(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    Structured expected = AsMap(value, AsValue);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_ListOfLists(string[][] value)
  {
    Structured expected = AsList(value, v => AsList(v, AsValue));

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_MapOfLists(MapPair<string[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    Structured expected = AsMap(value, v => AsList(v, AsValue));

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_ListOfMaps(MapPair<string>[][] value)
  {
    Assert.SkipWhen(value is null || value.Any(v => MapDups(v)), "Duplicate Keys in map");

    Structured expected = AsList(value, v => AsMap(v, AsValue));

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_MapOfMaps(MapPair<MapPair<string>[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value) || value.Any(v => MapDups(v.Value)), "Duplicate Keys in map");

    Structured expected = AsMap(value, v => AsMap(v, AsValue));

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }
}

namespace GqlPlus.Convert;

public abstract class StructureConvertTestsBase(IConvertTestsBase converters)
  : StructureConvertToTestsBase(converters)
{
  [Theory, RepeatData]
  public void ConvertFrom_AList(string value)
    => ConvertFrom_List([value]);

  [Theory, RepeatData]
  public void ConvertFrom_List(string[] value)
  {
    string[] input = Expected_List(value);
    Structured expected = AsList(value, AsValue);

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_AMap(MapPair<string> value)
    => ConvertFrom_Map([value]);

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
  public void ConvertFrom_AMapUntagged(MapPair<string> value)
    => ConvertFrom_MapUntagged([value]);

  [Theory, RepeatData]
  public void ConvertFrom_MapUntagged(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    string[] input = Expected_MapUntagged(value);
    Structured expected = AsMap(value, v => v.Encode());

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_AListOfLists(string value)
    => ConvertFrom_ListOfLists([[value]]);

  [Theory, RepeatData]
  public void ConvertFrom_ListOfLists(string[][] value)
  {
    string[] input = Expected_ListOfLists(value);
    Structured expected = AsList(value, v => AsList(v, AsValue));

    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertFrom_AMapOfLists(MapPair<string> value)
    => ConvertFrom_MapOfLists([value.Select(ToList)]);

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
  public void ConvertFrom_AListOfMaps(MapPair<string> value)
    => ConvertFrom_ListOfMaps([[value]]);

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
  public void ConvertFrom_AMapOfMaps(MapPair<MapPair<string>> value)
    => ConvertFrom_MapOfMaps([value.Select(ToList)]);

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
  public void RoundTrip_AList(string value)
    => RoundTrip_List([value]);

  [Theory, RepeatData]
  public void RoundTrip_List(string[] value)
  {
    Structured expected = AsList(value, AsValue);

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_AMap(MapPair<string> value)
    => RoundTrip_Map([value]);

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
  public void RoundTrip_AMapUntagged(MapPair<string> value)
    => RoundTrip_MapUntagged([value]);

  [Theory, RepeatData]
  public void RoundTrip_MapUntagged(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    Structured expected = AsMap(value, v => v.Encode());

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_AListOfLists(string value)
    => RoundTrip_ListOfLists([[value]]);

  [Theory, RepeatData]
  public void RoundTrip_ListOfLists(string[][] value)
  {
    Structured expected = AsList(value, v => AsList(v, AsValue));

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void RoundTrip_AMapOfLists(MapPair<string> value)
    => RoundTrip_MapOfLists([value.Select(ToList)]);

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
  public void RoundTrip_AListOfMaps(MapPair<string> value)
    => RoundTrip_ListOfMaps([[value]]);

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
  public void RoundTrip_AMapOfMaps(MapPair<MapPair<string>> value)
    => RoundTrip_MapOfMaps([value.Select(ToList)]);

  [Theory, RepeatData]
  public void RoundTrip_MapOfMaps(MapPair<MapPair<string>[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value) || value.Any(v => MapDups(v.Value)), "Duplicate Keys in map");

    Structured expected = AsMap(value, v => AsMap(v, AsValue));

    string[] input = Converters.ConvertTo(expected);
    Structured result = Converters.ConvertFrom(input);

    result.ShouldBe(expected);
  }

  private T[] ToList<T>(T item) => [item];
}

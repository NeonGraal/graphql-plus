namespace GqlPlus.Convert;

public abstract class ConvertStructureBase
{
  protected abstract string[] ConvertTo(Structured model);

  protected virtual bool Flow => false;
  protected virtual string ValueTag => "";
  protected virtual string ListTag => "";
  protected virtual string MapTag => "";
  protected abstract string[] Expected_List(string[] value);
  protected abstract string[] Expected_Map(MapPair<string>[] value);
  protected abstract string[] Expected_ListOfLists(string[][] value);
  protected abstract string[] Expected_MapOfLists(MapPair<string[]>[] value);
  protected abstract string[] Expected_ListOfMaps(MapPair<string>[][] value);
  protected abstract string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value);

  [Theory, RepeatData]
  public void ConvertTo_List(string[] value)
  {
    string[] expected = Expected_List(value);
    Structured model = AsList(value, AsValue);

    string[] result = ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_Map(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    string[] expected = Expected_Map(value);
    Structured model = AsMap(value, AsValue);

    string[] result = ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_ListOfLists(string[][] value)
  {
    string[] expected = Expected_ListOfLists(value);
    Structured model = AsList(value, v => AsList(v, AsValue));

    string[] result = ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_MapOfLists(MapPair<string[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    string[] expected = Expected_MapOfLists(value);
    Structured model = AsMap(value, v => AsList(v, AsValue));

    string[] result = ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_ListOfMaps(MapPair<string>[][] value)
  {
    Assert.SkipWhen(value is null || value.Any(v => MapDups(v)), "Duplicate Keys in map");

    string[] expected = Expected_ListOfMaps(value);
    Structured model = AsList(value, v => AsMap(v, AsValue));

    string[] result = ConvertTo(model);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ConvertTo_MapOfMaps(MapPair<MapPair<string>[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value) || value.Any(v => MapDups(v.Value)), "Duplicate Keys in map");

    string[] expected = Expected_MapOfMaps(value);
    Structured model = AsMap(value, v => AsMap(v, AsValue));

    string[] result = ConvertTo(model);

    result.ShouldBe(expected);
  }

  private Structured AsValue(string value)
    => new(value, ValueTag);

  private Structured AsList<T>(T[] value, Func<T, Structured> mapper)
    => value.Encode(mapper, ListTag, Flow);

  private Structured AsMap<T>(MapPair<T>[] value, Func<T, Structured> mapper)
    => value.ToMap(k => k.Key, v => mapper(v.Value)).Encode(MapTag, Flow);

  private static bool MapDups<T>(MapPair<T>[] value)
    => value.Length != value.Select(v => v.Key).Distinct(StringComparer.OrdinalIgnoreCase).Count();
}

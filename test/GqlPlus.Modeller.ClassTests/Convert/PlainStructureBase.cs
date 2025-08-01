namespace GqlPlus.Convert;

public abstract class PlainStructureBase
{
  protected abstract bool Flow { get; }
  protected abstract string ValueTag { get; }
  protected abstract string ListTag { get; }
  protected abstract string MapTag { get; }
  protected abstract string[] Expected_List(string[] value);
  protected abstract string[] Expected_Map(MapPair<string>[] value);
  protected abstract string[] Expected_ListOfLists(string[][] value);
  protected abstract string[] Expected_MapOfLists(MapPair<string[]>[] value);
  protected abstract string[] Expected_ListOfMaps(MapPair<string>[][] value);
  protected abstract string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value);

  [Theory, RepeatData]
  public void ToPlain_List(string[] value)
  {
    string[] expected = Expected_List(value);
    Structured model = AsList(value, AsValue);

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_Map(MapPair<string>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    string[] expected = Expected_Map(value);
    Structured model = AsMap(value, AsValue);

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_ListOfLists(string[][] value)
  {
    string[] expected = Expected_ListOfLists(value);
    Structured model = AsList(value, v => AsList(v, AsValue));

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_MapOfLists(MapPair<string[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value), "Duplicate Keys in map");

    string[] expected = Expected_MapOfLists(value);
    Structured model = AsMap(value, v => AsList(v, AsValue));

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_ListOfMaps(MapPair<string>[][] value)
  {
    Assert.SkipWhen(value is null || value.Any(v => MapDups(v)), "Duplicate Keys in map");

    string[] expected = Expected_ListOfMaps(value);
    Structured model = AsList(value, v => AsMap(v, AsValue));

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void ToPlain_MapOfMaps(MapPair<MapPair<string>[]>[] value)
  {
    Assert.SkipWhen(value is null || MapDups(value) || value.Any(v => MapDups(v.Value)), "Duplicate Keys in map");

    string[] expected = Expected_MapOfMaps(value);
    Structured model = AsMap(value, v => AsMap(v, AsValue));

    string[] result = model.ToPlain(false);

    result.ShouldBe(expected);
  }

  private Structured AsValue(string value)
    => new(value, ValueTag);

  private Structured AsList<T>(T[] value, Func<T, Structured> mapper)
    => value.Encode(mapper, ListTag, Flow);

  private Structured AsMap<T>(MapPair<T>[] value, Func<T, Structured> mapper)
    => value.ToMap(k => k.Key, v => mapper(v.Value)).Encode(MapTag, Flow);

  private static bool MapDups<T>(MapPair<T>[] value)
    => value.Length != value.Select(v => v.Key).Distinct().Count();
}

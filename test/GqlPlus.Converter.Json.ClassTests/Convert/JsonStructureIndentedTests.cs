namespace GqlPlus.Convert;

public class JsonStructureIndentedTests()
  : ConvertStructureTestsBase(JsonTestHelpers.Indented)
{
  protected override string[] Expected_List(string[] value)
    => [value.AsUnindentedList()];

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.AsIndentedMap();

  protected override string[] Expected_ListOfLists(string[][] value)
    => [value.AsIndentedList(v => [v!.AsUnindentedList()], "").SkipLast(1).Joined(""), "]"];

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.AsIndentedMap(v => [v!.AsUnindentedList()]);

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.AsIndentedList(v => v!.AsIndentedMap());

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.AsIndentedMap(v => v!.AsIndentedMap());
}

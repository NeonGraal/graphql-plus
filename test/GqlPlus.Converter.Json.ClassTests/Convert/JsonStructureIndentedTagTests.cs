namespace GqlPlus.Convert;

public class JsonStructureIndentedTagTests()
  : ConvertStructureTestsBase(JsonTestHelpers.Indented)
{
  protected override string ValueTag => "value";
  protected override string MapTag => "map";

  protected override string[] Expected_List(string[] value)
    => [value.AsUnindentedList(ValueTag.AsUnindentedValue(), ", ")];

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.AsIndentedMap(ValueTag.AsIndentedValue(), tag: MapTag);

  protected override string[] Expected_ListOfLists(string[][] value)
    => [value.AsIndentedList(v => [v!.AsUnindentedList(ValueTag.AsUnindentedValue(), ", ")], "").SkipLast(1).Joined(""), "]"];

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.AsIndentedMap(v => [v!.AsUnindentedList(ValueTag.AsUnindentedValue(), ", ")], tag: MapTag);

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.AsIndentedList(v => v!.AsIndentedMap(ValueTag.AsIndentedValue(), tag: MapTag));

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.AsIndentedMap(v => v!.AsIndentedMap(ValueTag.AsIndentedValue(), tag: MapTag), tag: MapTag);
}

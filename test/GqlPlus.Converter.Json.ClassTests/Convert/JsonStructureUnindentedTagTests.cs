namespace GqlPlus.Convert;

public class JsonStructureUnindentedTagTests()
  : ConvertStructureTestsBase(JsonTestHelpers.Unindented)
{
  protected override bool Flow => true;
  protected override string ValueTag => "value";
  protected override string MapTag => "map";

  protected override string[] Expected_List(string[] value)
    => [value.AsUnindentedList(ValueTag.AsUnindentedValue(), ", ")];

  protected override string[] Expected_Map(MapPair<string>[] value)
    => [value.AsUnindentedMap(ValueTag.AsUnindentedValue(""), MapTag)];

  protected override string[] Expected_ListOfLists(string[][] value)
    => [value.AsUnindentedList(v => v!.AsUnindentedList(ValueTag.AsUnindentedValue(), ", "))];

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => [value.AsUnindentedMap(v => v!.AsUnindentedList(ValueTag.AsUnindentedValue(), ", "), MapTag)];

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => [value.AsUnindentedList(v => v!.AsUnindentedMap(ValueTag.AsUnindentedValue(""), MapTag))];

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => [value.AsUnindentedMap(v => v!.AsUnindentedMap(ValueTag.AsUnindentedValue(""), MapTag), MapTag)];
}

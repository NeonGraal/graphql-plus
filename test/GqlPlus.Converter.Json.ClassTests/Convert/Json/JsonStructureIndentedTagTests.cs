namespace GqlPlus.Convert.Json;

public class JsonStructureIndentedTagTests()
  : StructureConvertTestsBase(JsonTestHelpers.Indented)
{
  protected override string ValueTag => "value";
  protected override string MapTag => "map";
  protected override string ListTag => "list";
  protected override string KeyTag => "key";

  protected override string[] Expected_List(string[] value)
    => value.AsIndentedList(
      ValueTag.AsIndentedValue(""),
      listTag: ListTag.JsonValue());

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.AsIndentedMap(
      ValueTag.AsIndentedValue(KeyTag.JsonValue()),
      mapTag: MapTag.JsonValue());

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.AsIndentedList(
      v => v!.AsIndentedList(
        ValueTag.AsIndentedValue(" "),
        listTag: ListTag.JsonValue()),
      listTag: ListTag.JsonValue());

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.AsIndentedMap(
      v => v!.AsIndentedList(
        ValueTag.AsIndentedValue(" "),
        listTag: ListTag.JsonValue(),
        keyTag: KeyTag.JsonValue()),
      mapTag: MapTag.JsonValue());

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.AsIndentedList(
      v => v!.AsIndentedMap(ValueTag.AsIndentedValue(KeyTag.JsonValue()),
        mapTag: MapTag.JsonValue()),
      listTag: ListTag.JsonValue());

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.AsIndentedMap(
      v => v!.AsIndentedMap(
        ValueTag.AsIndentedValue(KeyTag.JsonValue()),
        mapTag: MapTag.JsonValue(),
        keyTag: KeyTag.JsonValue()),
      mapTag: MapTag.JsonValue());
}

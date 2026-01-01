namespace GqlPlus.Convert.Plain;

public class PlainStructureTests()
  : StructureConvertTestsBase(PlainTestHelpers.Converters)
{
  protected override string[] Expected_List(string[] value)
  => value.BlockList(ValueTag.Tagged(), ListTag);

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.BlockMap(ValueTag.Tagged(), MapTag, KeyTag);

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.BlockList(v => v.BlockList(ValueTag.Tagged(), ListTag), ListTag);

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.BlockMap(v => v.BlockList(ValueTag.Tagged(), ListTag), MapTag, KeyTag);

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.BlockList(v => v.BlockMap(ValueTag.Tagged(), MapTag, KeyTag), ListTag);

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.BlockMap(v => v.BlockMap(ValueTag.Tagged(), MapTag, KeyTag), MapTag, KeyTag);
}

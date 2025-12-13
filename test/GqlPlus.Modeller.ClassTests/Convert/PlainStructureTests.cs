namespace GqlPlus.Convert;

public class PlainStructureTests()
  : ConvertStructureTestsBase(PlainTestHelpers.Converters)
{
  protected override string[] Expected_List(string[] value)
  => value.BlockList(ValueTag.Tagged());

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.BlockMap(ValueTag.Tagged(), MapTag);

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.BlockList(v => v.BlockList(ValueTag.Tagged()));

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.BlockMap(v => v.BlockList(ValueTag.Tagged()), MapTag);

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.BlockList(v => v.BlockMap(ValueTag.Tagged(), MapTag));

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.BlockMap(v => v.BlockMap(ValueTag.Tagged(), MapTag), MapTag);
}

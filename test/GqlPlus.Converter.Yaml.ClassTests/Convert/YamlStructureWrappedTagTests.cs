namespace GqlPlus.Convert;

public class YamlStructureWrappedTagTests()
  : ConvertStructureTestsBase(YamlTestHelpers.Wrapped)
{
  protected override string ValueTag => "value";
  protected override string MapTag => "map";

  protected override string[] Expected_List(string[] value)
  => value.BlockList("- !value ");

  protected override string[] Expected_Map(MapPair<string>[] value)
    => ["!map", .. value.BlockMap("", "!value ")];

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.BlockList(v => v!.BlockList("- !value ").PrefixFirst("- ", "  "));

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => ["!map", .. value.BlockMap(v => ["", .. v!.BlockList("- !value ")])];

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.BlockList(v => ["- !map", .. v!.BlockMap("  ", "!value ")]);

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => ["!map", .. value.BlockMap(v => ["!map", .. v!.BlockMap("  ", "!value ")])];
}

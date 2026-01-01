namespace GqlPlus.Convert.Yaml;

public class YamlStructureWrappedTagTests()
  : StructureConvertTestsBase(YamlTestHelpers.Wrapped)
{
  protected override string ValueTag => "value";
  protected override string MapTag => "map";
  protected override string ListTag => "list";
  protected override string KeyTag => "key";

  protected override string[] Expected_List(string[] value)
  => value.BlockList("- !value ", "!list");

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.BlockMap("!key ", "!value ", "!map");

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.BlockList(v => v!.BlockList("- !value ", "!list").PrefixFirst("- ", "  "), "!list");

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.BlockMap(v => v!.BlockList("- !value ", "!list"), "!key ", "!map");

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.BlockList(v => v!.BlockMap("  !key ", "!value ", "- !map"), "!list");

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.BlockMap(v => v!.BlockMap("  !key ", "!value ", "!map"), "!key ", "!map");
}

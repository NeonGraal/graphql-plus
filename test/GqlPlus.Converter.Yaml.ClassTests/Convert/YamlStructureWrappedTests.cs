namespace GqlPlus.Convert;

public class YamlStructureWrappedTests
  : ConvertStructureBase
{
  protected override string[] ConvertTo(Structured model)
    => model.ToYaml(true).ToLines();

  protected override string[] Expected_List(string[] value)
  => value.BlockList("- ");

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.BlockMap();

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.BlockList(v => v!.BlockList("- ").PrefixFirst("- ", "  "));

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.BlockMap(v => ["", .. v!.BlockList("- ")]);

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.BlockList(v => v!.BlockMap().PrefixFirst("- ", "  "));

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.BlockMap(v => ["", .. v!.BlockMap(b => [b!], "  ")]);
}

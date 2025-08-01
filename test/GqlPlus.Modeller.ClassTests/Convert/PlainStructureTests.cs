namespace GqlPlus.Convert;

public class PlainStructureTests
  : PlainStructureBase
{
  protected override bool Flow => false;
  protected override string ValueTag => "";
  protected override string ListTag => "";
  protected override string MapTag => "";

  protected override string[] Expected_List(string[] value)
  => value.BlockList("- ");

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.BlockMap();

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.BlockList(v => ["-", .. v!.BlockList("  - ")]);

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.BlockMap(v => ["", .. v!.BlockList("  - ")]);

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.BlockList(v => ["-", .. v!.BlockMap("  ")]);

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.BlockMap(v => ["", .. v!.BlockMap(b => [b!], "  ")]);
}

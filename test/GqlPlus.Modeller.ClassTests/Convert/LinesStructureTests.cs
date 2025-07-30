namespace GqlPlus.Convert;

public class LinesStructureTests
  : LinesStructureBase
{
  protected override bool Flow => false;
  protected override string ValueTag => "";
  protected override string ListTag => "";
  protected override string MapTag => "";

  protected override string[] Expected_List(string[] value)
  => (value.IsList("- ")).ToLines();

  protected override string[] Expected_Map(MapPair<string>[] value)
    => (value.IsMap("", " ")).ToLines();

  protected override string[] Expected_ListOfLists(string[][] value)
    => (value.IsList(v => "-" + Environment.NewLine + v!.IsList("  - "))).ToLines();

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => (value.IsMap(v => Environment.NewLine + v.IsList("  - "))).ToLines();

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => (value.IsList(v => "-" + Environment.NewLine + v!.IsMap("  ", " "))).ToLines();

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => (value.IsMap(v => Environment.NewLine + v.IsMap("  ", " "))).ToLines();
}

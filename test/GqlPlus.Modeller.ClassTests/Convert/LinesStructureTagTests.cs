namespace GqlPlus.Convert;

public class LinesStructureTagTests
  : LinesStructureBase
{
  protected override bool Flow => false;
  protected override string ValueTag => "value";
  protected override string ListTag => "list";
  protected override string MapTag => "map";

  protected override string Expected_List(string[] value)
  => value.IsList("- !value ");

  protected override string Expected_Map(MapPair<string>[] value)
    => "!map".WithLine() + value.IsMap("", " !value ");

  protected override string Expected_ListOfLists(string[][] value)
    => value.IsList(v => "-".WithLine() + v!.IsList("  - !value "));

  protected override string Expected_MapOfLists(MapPair<string[]>[] value)
    => "!map".WithLine() + value.IsMap(v => "".WithLine() + v.IsList("  - !value "));

  protected override string Expected_ListOfMaps(MapPair<string>[][] value)
    => value.IsList(v => "- !map".WithLine() + v!.IsMap("  ", " !value "));

  protected override string Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => "!map".WithLine() + value.IsMap(v => " !map".WithLine() + v.IsMap("  ", " !value "));
}

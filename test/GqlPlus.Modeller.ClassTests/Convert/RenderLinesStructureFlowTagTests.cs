namespace GqlPlus.Convert;

public class RenderLinesStructureFlowTagTests
  : RenderLinesStructureBase
{
  protected override bool Flow => true;
  protected override string ValueTag => "value";
  protected override string ListTag => "list";
  protected override string MapTag => "map";

  protected override string Expected_List(string[] value)
    => "!list " + value.FlowList("!value ");

  protected override string Expected_Map(MapPair<string>[] value)
    => "!map " + value.FlowMap("!value ");

  protected override string Expected_ListOfLists(string[][] value)
    => "!list".IsLine() + value.IsList(v => "- !list " + v!.FlowList("!value "));

  protected override string Expected_MapOfLists(MapPair<string[]>[] value)
    => "!map".IsLine() + value.IsMap("", v => " !list " + v.FlowList("!value "));

  protected override string Expected_ListOfMaps(MapPair<string>[][] value)
    => "!list".IsLine() + value.IsList(v => "- !map " + v!.FlowMap("!value "));

  protected override string Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => "!map".IsLine() + value.IsMap("", v => " !map " + v.FlowMap("!value "));
}

namespace GqlPlus.Convert;

public class RenderLinesStructureFlowTests
  : RenderLinesStructureBase
{
  protected override bool Flow => true;
  protected override string ValueTag => "";
  protected override string ListTag => "";
  protected override string MapTag => "";

  protected override string Expected_List(string[] value)
    => value.FlowList();

  protected override string Expected_Map(MapPair<string>[] value)
    => value.FlowMap();

  protected override string Expected_ListOfLists(string[][] value)
    => value.IsList(v => "- " + v!.FlowList());

  protected override string Expected_MapOfLists(MapPair<string[]>[] value)
    => value.IsMap("", v => " " + v.FlowList());

  protected override string Expected_ListOfMaps(MapPair<string>[][] value)
    => value.IsList(v => "- " + v!.FlowMap());

  protected override string Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.IsMap("", v => " " + v.FlowMap());
}

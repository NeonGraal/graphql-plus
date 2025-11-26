namespace GqlPlus.Convert;

public class YamlStructureFullTests
  : ConvertStructureBase
{
  protected override string[] ConvertTo(Structured model)
    => model.ToYaml(false).ToLines();

  protected override bool Flow => true;

  protected override string[] Expected_List(string[] value)
    => value.FlowList();

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.FlowMap();

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.FlowList(v => v!.FlowList());

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.FlowMap(v => v!.FlowList());

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.FlowList(v => v!.FlowMap());

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.FlowMap(v => v!.FlowMap());
}

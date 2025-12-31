namespace GqlPlus.Convert.SimpleYaml;

public class SimpleYamlStructureFlowTagTests()
  : StructureConvertToTestsBase(SimpleYamlTestHelpers.Converters)
{
  protected override bool Flow => true;
  protected override string ValueTag => "value";
  protected override string MapTag => "map";
  protected override string ListTag => "list";

  protected override string[] Expected_List(string[] value)
  => value.FlowList("!value ", "!list");

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.FlowMap("!map", "!value ");

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.FlowList(v => v!.FlowList("!value ", "!list"), "!list");

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.FlowMap(v => v!.FlowList("!value ", "!list"), "!map");

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.FlowList(v => v!.FlowMap("!map", "!value "), "!list");

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.FlowMap(v => v!.FlowMap("!map", "!value "), "!map");
}

namespace GqlPlus.Convert.Yaml;

public class YamlStructureFullTagTests()
  : StructureConvertTestsBase(YamlTestHelpers.Full)
{
  protected override bool Flow => true;
  protected override string ValueTag => "value";
  protected override string MapTag => "map";
  protected override string ListTag => "list";
  protected override string KeyTag => "key";

  protected override string[] Expected_List(string[] value)
    => value.FlowList("!value ", "!list ");

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.FlowMap("!map ", "!key ", "!value ");

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.FlowList(v => v!.FlowList("!value ", "!list ", "  "), "!list ");

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.FlowMap(v => v!.FlowList("!value ", "!list ", "  "), "!map ", "!key ");

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.FlowList(v => v!.FlowMap("!map ", "!key ", "!value ", "  "), "!list ");

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.FlowMap(v => v!.FlowMap("!map ", "!key ", "!value ", "  "), "!map ", "!key ");
}

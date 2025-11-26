using Xunit;

namespace GqlPlus.Convert;

public class JsonStructureUnindentedTests
  : ConvertStructureBase
{
  [Fact]
  public void ExplicitTo_Map()
  {
    MapPair<string>[] sample = [new("Jc", "zo1ixaI_p2V3_A4j_4Fy"), new("W", "ONl"), new("w", "Kc")];
    ConvertTo_Map(sample);
  }

  protected override string[] ConvertTo(Structured model)
    => model.ToJson(RenderJson.Unindented).ToLines();

  protected override bool Flow => true;

  protected override string[] Expected_List(string[] value)
    => [value.AsUnindentedList()];

  protected override string[] Expected_Map(MapPair<string>[] value)
    => [value.AsUnindentedMap()];

  protected override string[] Expected_ListOfLists(string[][] value)
    => [value.AsUnindentedList(v => v!.AsUnindentedList())];

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => [value.AsUnindentedMap(v => v!.AsUnindentedList())];

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => [value.AsUnindentedList(v => v!.AsUnindentedMap(), ",")];

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => [value.AsUnindentedMap(v => v!.AsUnindentedMap())];
}

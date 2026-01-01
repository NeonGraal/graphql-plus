using Xunit;

namespace GqlPlus.Convert.Json;

public class JsonStructureUnindentedTests()
  : StructureConvertTestsBase(JsonTestHelpers.Unindented)
{
  [Fact]
  public void ExplicitTo_MapOfMaps()
  {
    MapPair<MapPair<string>[]>[] sample = [
      new("i1_",[
        new("Ofxg_hf_","hlwcFC_NG__N_O"),
        new("QVe__MC71","K"),
        new("o","H556__")]),
      new("Nw_0__84_", [
        new("H_NsVcK4jK","Mk"),
        new("YO","vt5_nS___"),
        new("VP0_V","oDB")]),
      new("SJ__k_2_P",[
        new("n___","R2Vn"),
        new("g","J"),
        new("Nw7","P__Q")])];
    // [new("Jc", "zo1ixaI_p2V3_A4j_4Fy"), new("W", "ONl"), new("w", "Kc")];
    ConvertTo_MapOfMaps(sample);
  }

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
    => [value.AsUnindentedList(v => v!.AsUnindentedMap())];

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => [value.AsUnindentedMap(v => v!.AsUnindentedMap())];
}

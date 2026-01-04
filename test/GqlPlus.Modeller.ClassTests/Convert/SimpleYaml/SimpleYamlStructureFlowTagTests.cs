using Newtonsoft.Json.Linq;

namespace GqlPlus.Convert.SimpleYaml;

public class SimpleYamlStructureFlowTagTests()
  : StructureConvertToTestsBase(SimpleYamlTestHelpers.Converters)
{
  [Fact]
  public void ConvertTo_ListOfMaps_Specific()
    => ConvertTo_ListOfMaps(value: [
      [new("Lu_C", "YB"), new("I", "p_P0C_F"), new("VUR_mm3Z7", "u")],
      [new("eb_a9WT_m", "Xw3M5n"), new("hb__Zd", "dO033zOS9sC6___GQf__t_de__Mw_y2__T_l7_T_M6___Xt_t__J"), new("e__6w2F0GwH_Q_sD_", "M_Rm")],
      [new("G", "Cd"), new("u12S9QmHS_WY_9_dRZ8Q77t7", "H94UXY0"), new("W", "Uw_HR_e4k")]]);

  [Fact]
  public void ConvertTo_ListOfLists_Specific()
    => ConvertTo_ListOfLists([
      ["kG5", "S__"],
      ["U_aL_v9z_Yp6WSu", "S01_v2k___If22_sNj6xWjF9", "r_077_Sa_3f43B", "hE_2c_S91l2inAp__qnEg_2_x8F3D132H", "N1bj_l9_Hh_"],
      ["d794", "Vs4", "q_5Q8vR1M"]]);

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
    => value.FlowMap(v => v!.FlowMap("!map", "!value ", "  "), "!map");
}

namespace GqlPlus.Convert;

public class PlainStructureFlowTests()
  : ConvertStructureTestsBase(PlainTestHelpers.Converters)
{
  [Fact]
  public void ConvertTo_ListOfMaps_Specific()
  {
    MapPair<string>[][] value = [
      [new("iw1_", "r_47"), new("qei_nNY", "m" ), new("Q866_", "tE_e3o_Rl9dCn_vh_rH7" )],
      [new("r8tkWB9_7", "i" ), new("e", "tW" ), new("b_", "y" )],
      [new("IN_1__oYnsOow____0Gm_8_yLPMm9X4435", "v" ), new("xh_N_e_0_A22_n_____6Q_7___UrRSa_lG39_OSa3p_z_A4_l_44_T2", "w8tK" ), new("bF_f3_gu_Eno_", "p___6" )]
    ];

    ConvertTo_ListOfMaps(value);
  }

  [Fact]
  public void ConvertTo_ListOfMaps_Specific1()
  {
    MapPair<string>[][] value = [
      [new("MY0a_D","wtC7S__1HcM"), new("t","O"), new("E","sWR")],
      [new("HD8Cj","nGQ9J4hp60_"), new("J1Z","qO02"), new("KFRU6__3mamiu","Z")],
      [new("n__JX","o_E_T_"), new("gx","OvZ2"), new("vZUjj","L5WB_3Y_ES79D")]
    ];

    ConvertTo_ListOfMaps(value);
  }

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

namespace GqlPlus.Convert;

public class LinesStructureFlowTests
  : LinesStructureBase
{
  [Fact]
  public void ToLines_ListOfMaps_Specific()
  {
    MapPair<string>[][] value = [
      [new("iw1_", "r_47"), new("qei_nNY", "m" ), new("Q866_", "tE_e3o_Rl9dCn_vh_rH7" )],
      [new("r8tkWB9_7", "i" ), new("e", "tW" ), new("b_", "y" )],
      [new("IN_1__oYnsOow____0Gm_8_yLPMm9X4435", "v" ), new("xh_N_e_0_A22_n_____6Q_7___UrRSa_lG39_OSa3p_z_A4_l_44_T2", "w8tK" ), new("bF_f3_gu_Eno_", "p___6" )]
    ];

    ToLines_ListOfMaps(value);
  }

  protected override bool Flow => true;
  protected override string ValueTag => "";
  protected override string ListTag => "";
  protected override string MapTag => "";

  protected override string[] Expected_List(string[] value)
    => value.FlowList().ToLines();

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.FlowMap().ToLines();

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.FlowList(v => v!.FlowList()).ToLines();

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.FlowMap((p, v) => p + v.FlowList()).ToLines();

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.FlowList(v => v!.FlowMap()).ToLines();

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.FlowMap((p, v) => v.FlowMap(p)).ToLines();
}

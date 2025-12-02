namespace GqlPlus.Convert;

public class PlainStructureFlowTagTests()
  : ConvertStructureTestsBase(PlainTestHelpers.Converters)
{
  [Fact]
  public void ConvertTo_ListOfLists_Specific()
  {
    string[][] value = [
      ["W8XtjV_8d0_8FM6dqGHdBax_e_Go_24GKaBR1Q_qIBfS_Yr_SO", "am_J9", "jh_3fk41___fu_5_OsplL2X_61u", "Y_", "T"],
      ["j_"],
      ["NMQP_871F", "N_h____w9_4OV_a1Lcfh6"]];

    ConvertTo_ListOfLists(value);
  }

  [Fact]
  public void ConvertTo_ListOfMaps_Specific()
  {
    MapPair<string>[][] value = [
      [new("WvF_KT", "fD3k_"), new("ys6Vh", "X"), new("o", "MN6Y1__b_3M") ],
      [new("r6qOg_gxcuFNNm3IB3_ck_T8_7FJ", "z0k___y54"), new("r_NI3dbPl3V5__", "w_8____et_YpY6F_Wjc_x6") , new("y2pM4", "E_WvD76sISK8S_")],
      [new("TVHM", "o7") , new("A", "qQR_jBG2H_") , new("X_e_F", "uc")]
      ];

    ConvertTo_ListOfMaps(value);
  }

  [Fact]
  public void ConvertTo_Map_Specific()
  {
    MapPair<string>[] value = [
      new("rAN1X_c1___No1YUC_ds_E_", "HaKYUJM0L "),
      new("vF_8F14s_QoB_", "g24_gm_1MQ__k"),
      new ("Z_1W0nm__2_aB", "O_81O0saDYY_G81b0P0")];

    ConvertTo_Map(value);
  }

  [Fact]
  public void ConvertTo_MapOfLists_Specific()
  {
    MapPair<string[]>[] value = [
      new("w", ["u", "G36","M57_"]),
      new("wS", ["dK", "L", "g5K", "C__bu_128", "A33PX"]),
      new("x9", ["i"])
      ];

    ConvertTo_MapOfLists(value);
  }

  [Fact]
  public void ConvertTo_MapOfLists_Specific1()
  {
    MapPair<string[]>[] value = [
      new("RV_", ["s4AVrwq7Kgqwr_yk", "g_985rRj_", "yW6Kn7_j6V7n_5W1bmq1M4XhR", "m__bq0871k2tzQB", "w__UsN28Ge_5x_B_78"]),
      new("XAo___mt", ["JzU", "i8R__", "A_", "Aj"]),
      new("I", ["w"])
      ];

    ConvertTo_MapOfLists(value);
  }

  [Fact]
  public void ConvertTo_MapOfMaps_Specific()
  {
    MapPair<MapPair<string>[]>[] value = [
      new("fW__8__i6", [new("Jx","L"), new("nW7Bwe20a__","p4_u__c_S"),new("uE5Bl0aOqrGG_5cH_7CUMp","uo88__Rh0ikg_13_60kW_AC_OIR_ok_KzvW8Y_yq5_j")]),
      new("O62__7_", [new("GW_V2ls_", "b_IsR8U"), new("o3pY__o", "NK_"), new("pPLt1", "P")]),
      new("cb3Dj2c", [new("B_h_j_XV", "cK___iv"), new("C", "A4__e5X_"), new("u6U_Vo", "r0wE")])
      ];

    ConvertTo_MapOfMaps(value);
  }

  protected override bool Flow => true;
  protected override string ValueTag => "value";
  //protected override string ListTag => "list";
  protected override string MapTag => "map";

  protected override string[] Expected_List(string[] value)
    => value.FlowList("!value ");

  protected override string[] Expected_Map(MapPair<string>[] value)
    => value.FlowMap("!map", "!value ");

  protected override string[] Expected_ListOfLists(string[][] value)
    => value.FlowList(v => v!.FlowList("!value ", "  "));

  protected override string[] Expected_MapOfLists(MapPair<string[]>[] value)
    => value.FlowMap(v => v!.FlowList("!value ", "  "), "!map");

  protected override string[] Expected_ListOfMaps(MapPair<string>[][] value)
    => value.FlowList(v => v!.FlowMap("!map", "!value ", "  "));

  protected override string[] Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.FlowMap(v => v!.FlowMap("!map", "!value ", "  "), "!map");
}

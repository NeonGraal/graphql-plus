﻿namespace GqlPlus.Convert;

public class LinesStructureFlowTagTests
  : LinesStructureBase
{
  [Fact]
  public void ToLines_ListOfLists_Specific()
  {
    string[][] value = [
      ["W8XtjV_8d0_8FM6dqGHdBax_e_Go_24GKaBR1Q_qIBfS_Yr_SO", "am_J9", "jh_3fk41___fu_5_OsplL2X_61u", "Y_", "T"],
      ["j_"],
      ["NMQP_871F", "N_h____w9_4OV_a1Lcfh6"]];

    ToLines_ListOfLists(value);
  }

  [Fact]
  public void ToLines_Map_Specific()
  {
    MapPair<string>[] value = [
      new("rAN1X_c1___No1YUC_ds_E_", "HaKYUJM0L "),
      new("vF_8F14s_QoB_", "g24_gm_1MQ__k"),
      new ("Z_1W0nm__2_aB", "O_81O0saDYY_G81b0P0")];

    ToLines_Map(value);
  }

  [Fact]
  public void ToLines_MapOfMaps_Specific()
  {
    MapPair<MapPair<string>[]>[] value = [
      new("fW__8__i6", [new("Jx","L"), new("nW7Bwe20a__","p4_u__c_S"),new("uE5Bl0aOqrGG_5cH_7CUMp","uo88__Rh0ikg_13_60kW_AC_OIR_ok_KzvW8Y_yq5_j")]),
      new("O62__7_", [new("GW_V2ls_", "b_IsR8U"), new("o3pY__o", "NK_"), new("pPLt1", "P")]),
      new("cb3Dj2c", [new("B_h_j_XV", "cK___iv"), new("C", "A4__e5X_"), new("u6U_Vo", "r0wE")])
      ];

    ToLines_MapOfMaps(value);
  }

  protected override bool Flow => true;
  protected override string ValueTag => "value";
  protected override string ListTag => "list";
  protected override string MapTag => "map";

  protected override string Expected_List(string[] value)
    => value.FlowList("!value ");

  protected override string Expected_Map(MapPair<string>[] value)
    => value.FlowMap("!map", "!value ");

  protected override string Expected_ListOfLists(string[][] value)
    => value.FlowList(v => v!.FlowList("!value ", "  "));

  protected override string Expected_MapOfLists(MapPair<string[]>[] value)
    => value.FlowMap(v => v.FlowList("!value ", "  "), "!map");

  protected override string Expected_ListOfMaps(MapPair<string>[][] value)
    => value.FlowList(v => v!.FlowMap("!map", "!value "));

  protected override string Expected_MapOfMaps(MapPair<MapPair<string>[]>[] value)
    => value.FlowMap(v => v.FlowMap("!map", "!value ", "  "), "!map");
}

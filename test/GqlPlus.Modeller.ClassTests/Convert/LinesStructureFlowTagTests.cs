namespace GqlPlus.Convert;

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
    => value.FlowMap(v => v.FlowMap("!map", "!value "), "!map");
}

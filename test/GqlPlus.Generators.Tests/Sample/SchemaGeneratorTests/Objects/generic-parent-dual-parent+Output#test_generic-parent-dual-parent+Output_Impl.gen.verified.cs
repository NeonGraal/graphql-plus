//HintName: test_generic-parent-dual-parent+Output_Impl.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public class OutputtestGnrcPrntDualPrntOutp
  : OutputtestRefGnrcPrntDualPrntOutp
  , ItestGnrcPrntDualPrntOutp
{
}

public class OutputtestRefGnrcPrntDualPrntOutp<Tref>
  : Outputtestref
  , ItestRefGnrcPrntDualPrntOutp<Tref>
{
}

public class DualtestAltGnrcPrntDualPrntOutp
  : ItestAltGnrcPrntDualPrntOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

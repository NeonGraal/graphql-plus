//HintName: test_generic-parent-dual-parent+Output_Intf.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp
{
  public testGnrcPrntDualPrntOutp GnrcPrntDualPrntOutp { get; set; }
}

public interface ItestGnrcPrntDualPrntOutpField
  : ItestRefGnrcPrntDualPrntOutpField
{
}

public interface ItestRefGnrcPrntDualPrntOutp<Tref>
  : Itestref
{
  public testRefGnrcPrntDualPrntOutp RefGnrcPrntDualPrntOutp { get; set; }
}

public interface ItestRefGnrcPrntDualPrntOutpField<Tref>
  : ItestrefField
{
}

public interface ItestAltGnrcPrntDualPrntOutp
{
  public testString AsString { get; set; }
  public testAltGnrcPrntDualPrntOutp AltGnrcPrntDualPrntOutp { get; set; }
}

public interface ItestAltGnrcPrntDualPrntOutpField
{
  public testNumber alt { get; set; }
}

//HintName: test_generic-parent-dual+Output_Intf.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp
{
  public testGnrcPrntDualOutp GnrcPrntDualOutp { get; set; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject
{
}

public interface ItestRefGnrcPrntDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntDualOutp RefGnrcPrntDualOutp { get; set; }
}

public interface ItestRefGnrcPrntDualOutpObject<Tref>
{
}

public interface ItestAltGnrcPrntDualOutp
{
  public testString AsString { get; set; }
  public testAltGnrcPrntDualOutp AltGnrcPrntDualOutp { get; set; }
}

public interface ItestAltGnrcPrntDualOutpObject
{
  public testNumber alt { get; set; }
}

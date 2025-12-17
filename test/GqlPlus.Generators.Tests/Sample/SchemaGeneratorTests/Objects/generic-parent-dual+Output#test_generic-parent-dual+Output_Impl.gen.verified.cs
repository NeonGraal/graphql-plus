//HintName: test_generic-parent-dual+Output_Impl.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public class testGnrcPrntDualOutp
  : testRefGnrcPrntDualOutp
  , ItestGnrcPrntDualOutp
{
  public testGnrcPrntDualOutp GnrcPrntDualOutp { get; set; }
}

public class testRefGnrcPrntDualOutp<Tref>
  : ItestRefGnrcPrntDualOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntDualOutp RefGnrcPrntDualOutp { get; set; }
}

public class testAltGnrcPrntDualOutp
  : ItestAltGnrcPrntDualOutp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntDualOutp AltGnrcPrntDualOutp { get; set; }
}

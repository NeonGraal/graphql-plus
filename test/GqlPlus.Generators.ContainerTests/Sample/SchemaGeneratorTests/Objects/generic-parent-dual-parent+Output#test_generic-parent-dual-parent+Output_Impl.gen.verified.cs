//HintName: test_generic-parent-dual-parent+Output_Impl.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public class testGnrcPrntDualPrntOutp
  : testRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
  , ItestGnrcPrntDualPrntOutp
{
}

public class testRefGnrcPrntDualPrntOutp<TRef>
  : ItestRefGnrcPrntDualPrntOutp<TRef>
{
}

public class testAltGnrcPrntDualPrntOutp
  : ItestAltGnrcPrntDualPrntOutp
{
  public decimal Alt { get; set; }
}

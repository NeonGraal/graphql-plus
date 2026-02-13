//HintName: test_generic-parent-dual-parent+Output_Impl.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public class testGnrcPrntDualPrntOutp
  : testRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
  , ItestGnrcPrntDualPrntOutp
{
  public ItestGnrcPrntDualPrntOutpObject AsGnrcPrntDualPrntOutp { get; set; }
}

public class testRefGnrcPrntDualPrntOutp<TRef>
  : ItestRefGnrcPrntDualPrntOutp<TRef>
{
  public TRef AsParent { get; set; }
  public ItestRefGnrcPrntDualPrntOutpObject<TRef> AsRefGnrcPrntDualPrntOutp { get; set; }
}

public class testAltGnrcPrntDualPrntOutp
  : ItestAltGnrcPrntDualPrntOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualPrntOutpObject AsAltGnrcPrntDualPrntOutp { get; set; }
}

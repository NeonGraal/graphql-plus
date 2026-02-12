//HintName: test_generic-parent-dual+Output_Impl.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public class testGnrcPrntDualOutp
  : testRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
  , ItestGnrcPrntDualOutp
{
  public ItestGnrcPrntDualOutpObject AsGnrcPrntDualOutp { get; set; }
}

public class testRefGnrcPrntDualOutp<TRef>
  : ItestRefGnrcPrntDualOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntDualOutpObject<TRef> AsRefGnrcPrntDualOutp { get; set; }
}

public class testAltGnrcPrntDualOutp
  : ItestAltGnrcPrntDualOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualOutpObject AsAltGnrcPrntDualOutp { get; set; }
}

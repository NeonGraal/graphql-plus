//HintName: test_generic-parent-dual-parent+Dual_Impl.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public class testGnrcPrntDualPrntDual
  : testRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
  , ItestGnrcPrntDualPrntDual
{
  public ItestGnrcPrntDualPrntDualObject AsGnrcPrntDualPrntDual { get; set; }
}

public class testRefGnrcPrntDualPrntDual<TRef>
  : ItestRefGnrcPrntDualPrntDual<TRef>
{
  public TRef AsParent { get; set; }
  public ItestRefGnrcPrntDualPrntDualObject<TRef> AsRefGnrcPrntDualPrntDual { get; set; }
}

public class testAltGnrcPrntDualPrntDual
  : ItestAltGnrcPrntDualPrntDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualPrntDualObject AsAltGnrcPrntDualPrntDual { get; set; }
}

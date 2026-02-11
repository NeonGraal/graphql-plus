//HintName: test_generic-parent-dual+Dual_Impl.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public class testGnrcPrntDualDual
  : testRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
  , ItestGnrcPrntDualDual
{
  public ItestGnrcPrntDualDualObject AsGnrcPrntDualDual { get; set; }
}

public class testRefGnrcPrntDualDual<TRef>
  : ItestRefGnrcPrntDualDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntDualDualObject AsRefGnrcPrntDualDual { get; set; }
}

public class testAltGnrcPrntDualDual
  : ItestAltGnrcPrntDualDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualDualObject AsAltGnrcPrntDualDual { get; set; }
}

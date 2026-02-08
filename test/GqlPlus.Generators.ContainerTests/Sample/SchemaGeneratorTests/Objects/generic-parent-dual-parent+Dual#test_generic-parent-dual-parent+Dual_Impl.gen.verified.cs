//HintName: test_generic-parent-dual-parent+Dual_Impl.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public class testGnrcPrntDualPrntDual
  : testRefGnrcPrntDualPrntDual
  , ItestGnrcPrntDualPrntDual
{
  public ItestGnrcPrntDualPrntDualObject AsGnrcPrntDualPrntDual { get; set; }
}

public class testRefGnrcPrntDualPrntDual<Tref>
  : testref
  , ItestRefGnrcPrntDualPrntDual<Tref>
{
  public ItestRefGnrcPrntDualPrntDualObject AsRefGnrcPrntDualPrntDual { get; set; }
}

public class testAltGnrcPrntDualPrntDual
  : ItestAltGnrcPrntDualPrntDual
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltGnrcPrntDualPrntDualObject AsAltGnrcPrntDualPrntDual { get; set; }
}

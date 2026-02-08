//HintName: test_generic-parent-dual-parent+Dual_Impl.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public class testGnrcPrntDualPrntDual
  : testRefGnrcPrntDualPrntDual
  , ItestGnrcPrntDualPrntDual
{
}

public class testRefGnrcPrntDualPrntDual<Tref>
  : testref
  , ItestRefGnrcPrntDualPrntDual<Tref>
{
}

public class testAltGnrcPrntDualPrntDual
  : ItestAltGnrcPrntDualPrntDual
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}

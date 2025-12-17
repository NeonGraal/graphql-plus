//HintName: test_generic-parent-dual-parent+Dual_Impl.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public class testGnrcPrntDualPrntDual
  : testRefGnrcPrntDualPrntDual
  , ItestGnrcPrntDualPrntDual
{
  public testGnrcPrntDualPrntDual GnrcPrntDualPrntDual { get; set; }
}

public class testRefGnrcPrntDualPrntDual<Tref>
  : testref
  , ItestRefGnrcPrntDualPrntDual<Tref>
{
  public testRefGnrcPrntDualPrntDual RefGnrcPrntDualPrntDual { get; set; }
}

public class testAltGnrcPrntDualPrntDual
  : ItestAltGnrcPrntDualPrntDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntDualPrntDual AltGnrcPrntDualPrntDual { get; set; }
}

//HintName: test_generic-parent-dual-parent+Dual_Intf.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual
{
  public testGnrcPrntDualPrntDual GnrcPrntDualPrntDual { get; set; }
}

public interface ItestGnrcPrntDualPrntDualObject
  : ItestRefGnrcPrntDualPrntDualObject
{
}

public interface ItestRefGnrcPrntDualPrntDual<Tref>
  : Itestref
{
  public testRefGnrcPrntDualPrntDual RefGnrcPrntDualPrntDual { get; set; }
}

public interface ItestRefGnrcPrntDualPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntDualPrntDual
{
  public testString AsString { get; set; }
  public testAltGnrcPrntDualPrntDual AltGnrcPrntDualPrntDual { get; set; }
}

public interface ItestAltGnrcPrntDualPrntDualObject
{
  public testNumber alt { get; set; }
}

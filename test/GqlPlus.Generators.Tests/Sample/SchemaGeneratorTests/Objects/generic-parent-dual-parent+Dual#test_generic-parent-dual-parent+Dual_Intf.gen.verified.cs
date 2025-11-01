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

public interface ItestGnrcPrntDualPrntDualField
  : ItestRefGnrcPrntDualPrntDualField
{
}

public interface ItestRefGnrcPrntDualPrntDual<Tref>
  : Itestref
{
  public testRefGnrcPrntDualPrntDual RefGnrcPrntDualPrntDual { get; set; }
}

public interface ItestRefGnrcPrntDualPrntDualField<Tref>
  : ItestrefField
{
}

public interface ItestAltGnrcPrntDualPrntDual
{
  public testString AsString { get; set; }
  public testAltGnrcPrntDualPrntDual AltGnrcPrntDualPrntDual { get; set; }
}

public interface ItestAltGnrcPrntDualPrntDualField
{
  public testNumber alt { get; set; }
}

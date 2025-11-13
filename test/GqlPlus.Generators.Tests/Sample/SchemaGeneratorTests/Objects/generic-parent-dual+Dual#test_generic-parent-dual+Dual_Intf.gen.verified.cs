//HintName: test_generic-parent-dual+Dual_Intf.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual
{
  public testGnrcPrntDualDual GnrcPrntDualDual { get; set; }
}

public interface ItestGnrcPrntDualDualField
  : ItestRefGnrcPrntDualDualField
{
}

public interface ItestRefGnrcPrntDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntDualDual RefGnrcPrntDualDual { get; set; }
}

public interface ItestRefGnrcPrntDualDualField<Tref>
{
}

public interface ItestAltGnrcPrntDualDual
{
  public testString AsString { get; set; }
  public testAltGnrcPrntDualDual AltGnrcPrntDualDual { get; set; }
}

public interface ItestAltGnrcPrntDualDualField
{
  public testNumber alt { get; set; }
}

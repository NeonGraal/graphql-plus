//HintName: test_generic-parent-dual+Dual_Impl.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public class testGnrcPrntDualDual
  : testRefGnrcPrntDualDual
  , ItestGnrcPrntDualDual
{
  public testGnrcPrntDualDual GnrcPrntDualDual { get; set; }
}

public class testRefGnrcPrntDualDual<Tref>
  : ItestRefGnrcPrntDualDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntDualDual RefGnrcPrntDualDual { get; set; }
}

public class testAltGnrcPrntDualDual
  : ItestAltGnrcPrntDualDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltGnrcPrntDualDual AltGnrcPrntDualDual { get; set; }
}

//HintName: test_generic-parent-dual+Dual_Impl.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public class testGnrcPrntDualDual
  : testRefGnrcPrntDualDual
  , ItestGnrcPrntDualDual
{
}

public class testRefGnrcPrntDualDual<Tref>
  : ItestRefGnrcPrntDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcPrntDualDual
  : ItestAltGnrcPrntDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

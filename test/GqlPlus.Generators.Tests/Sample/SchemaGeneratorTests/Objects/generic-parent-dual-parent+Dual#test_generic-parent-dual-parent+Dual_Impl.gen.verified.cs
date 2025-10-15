//HintName: test_generic-parent-dual-parent+Dual_Impl.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public class DualtestGnrcPrntDualPrntDual
  : DualtestRefGnrcPrntDualPrntDual
  , ItestGnrcPrntDualPrntDual
{
}

public class DualtestRefGnrcPrntDualPrntDual<Tref>
  : Dualtestref
  , ItestRefGnrcPrntDualPrntDual<Tref>
{
}

public class DualtestAltGnrcPrntDualPrntDual
  : ItestAltGnrcPrntDualPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

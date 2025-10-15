//HintName: test_generic-parent-dual+Dual_Impl.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public class DualtestGnrcPrntDualDual
  : DualtestRefGnrcPrntDualDual
  , ItestGnrcPrntDualDual
{
}

public class DualtestRefGnrcPrntDualDual<Tref>
  : ItestRefGnrcPrntDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestAltGnrcPrntDualDual
  : ItestAltGnrcPrntDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

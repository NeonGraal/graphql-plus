//HintName: test_generic-parent-dual-parent+Dual_Intf.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual
{
}

public interface ItestRefGnrcPrntDualPrntDual<Tref>
  : Itestref
{
}

public interface ItestAltGnrcPrntDualPrntDual
{
  Number alt { get; }
  String AsString { get; }
}

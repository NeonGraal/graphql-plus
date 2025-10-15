//HintName: test_generic-parent-dual+Dual_Intf.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual
{
}

public interface ItestRefGnrcPrntDualDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcPrntDualDual
{
  Number alt { get; }
  String AsString { get; }
}

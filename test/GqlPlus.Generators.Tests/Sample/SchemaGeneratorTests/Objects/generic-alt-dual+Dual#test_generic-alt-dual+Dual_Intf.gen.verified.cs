//HintName: test_generic-alt-dual+Dual_Intf.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public interface ItestGnrcAltDualDual
{
  RefGnrcAltDualDual<AltGnrcAltDualDual> AsRefGnrcAltDualDual { get; }
}

public interface ItestRefGnrcAltDualDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcAltDualDual
{
  Number alt { get; }
  String AsString { get; }
}

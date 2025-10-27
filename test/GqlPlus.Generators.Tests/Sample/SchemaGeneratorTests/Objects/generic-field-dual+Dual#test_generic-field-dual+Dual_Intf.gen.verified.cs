//HintName: test_generic-field-dual+Dual_Intf.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public interface ItestGnrcFieldDualDual
{
  RefGnrcFieldDualDual<AltGnrcFieldDualDual> field { get; }
}

public interface ItestRefGnrcFieldDualDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcFieldDualDual
{
  Number alt { get; }
  String AsString { get; }
}

//HintName: test_generic-field-dual+Dual_Intf.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public interface ItestGnrcFieldDualDual
{
  ItestGnrcFieldDualDualObject AsGnrcFieldDualDual { get; }
}

public interface ItestGnrcFieldDualDualObject
{
  ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; }
}

public interface ItestRefGnrcFieldDualDual<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcFieldDualDualObject AsRefGnrcFieldDualDual { get; }
}

public interface ItestRefGnrcFieldDualDualObject<Tref>
{
}

public interface ItestAltGnrcFieldDualDual
{
  string AsString { get; }
  ItestAltGnrcFieldDualDualObject AsAltGnrcFieldDualDual { get; }
}

public interface ItestAltGnrcFieldDualDualObject
{
  decimal Alt { get; }
}

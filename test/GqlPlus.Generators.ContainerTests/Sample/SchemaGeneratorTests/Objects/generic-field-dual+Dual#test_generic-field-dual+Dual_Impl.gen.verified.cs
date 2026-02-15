//HintName: test_generic-field-dual+Dual_Impl.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class testGnrcFieldDualDual
  : ItestGnrcFieldDualDual
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }
}

public class testRefGnrcFieldDualDual<TRef>
  : ItestRefGnrcFieldDualDual<TRef>
{
}

public class testAltGnrcFieldDualDual
  : ItestAltGnrcFieldDualDual
{
  public decimal Alt { get; set; }
}

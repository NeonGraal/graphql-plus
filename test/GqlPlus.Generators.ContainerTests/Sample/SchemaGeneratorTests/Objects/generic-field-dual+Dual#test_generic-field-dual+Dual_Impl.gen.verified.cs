//HintName: test_generic-field-dual+Dual_Impl.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public class testGnrcFieldDualDual
  : ItestGnrcFieldDualDual
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }
  public ItestGnrcFieldDualDualObject AsGnrcFieldDualDual { get; set; }
}

public class testRefGnrcFieldDualDual<Tref>
  : ItestRefGnrcFieldDualDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldDualDualObject AsRefGnrcFieldDualDual { get; set; }
}

public class testAltGnrcFieldDualDual
  : ItestAltGnrcFieldDualDual
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltGnrcFieldDualDualObject AsAltGnrcFieldDualDual { get; set; }
}

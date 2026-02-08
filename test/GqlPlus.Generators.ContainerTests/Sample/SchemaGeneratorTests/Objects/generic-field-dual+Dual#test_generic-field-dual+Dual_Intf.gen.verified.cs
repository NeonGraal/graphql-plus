//HintName: test_generic-field-dual+Dual_Intf.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public interface ItestGnrcFieldDualDual
{
  public ItestGnrcFieldDualDualObject AsGnrcFieldDualDual { get; set; }
}

public interface ItestGnrcFieldDualDualObject
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }
}

public interface ItestRefGnrcFieldDualDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcFieldDualDualObject AsRefGnrcFieldDualDual { get; set; }
}

public interface ItestRefGnrcFieldDualDualObject<Tref>
{
}

public interface ItestAltGnrcFieldDualDual
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcFieldDualDualObject AsAltGnrcFieldDualDual { get; set; }
}

public interface ItestAltGnrcFieldDualDualObject
{
  public ItestNumber Alt { get; set; }
}

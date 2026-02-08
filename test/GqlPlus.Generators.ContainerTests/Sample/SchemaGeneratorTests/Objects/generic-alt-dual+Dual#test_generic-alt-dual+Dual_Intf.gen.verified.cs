//HintName: test_generic-alt-dual+Dual_Intf.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public interface ItestGnrcAltDualDual
{
  public ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
}

public interface ItestGnrcAltDualDualObject
{
}

public interface ItestRefGnrcAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcAltDualDualObject<Tref>
{
}

public interface ItestAltGnrcAltDualDual
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcAltDualDualObject
{
  public ItestNumber Alt { get; set; }
}

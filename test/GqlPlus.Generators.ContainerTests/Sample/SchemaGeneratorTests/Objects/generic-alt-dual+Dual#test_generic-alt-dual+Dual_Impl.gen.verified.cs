//HintName: test_generic-alt-dual+Dual_Impl.gen.cs
// Generated from generic-alt-dual+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

public class testGnrcAltDualDual
  : ItestGnrcAltDualDual
{
  public ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
  public ItestGnrcAltDualDualObject AsGnrcAltDualDual { get; set; }
}

public class testRefGnrcAltDualDual<Tref>
  : ItestRefGnrcAltDualDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltDualDualObject AsRefGnrcAltDualDual { get; set; }
}

public class testAltGnrcAltDualDual
  : ItestAltGnrcAltDualDual
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltGnrcAltDualDualObject AsAltGnrcAltDualDual { get; set; }
}

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

public class testRefGnrcAltDualDual<TRef>
  : ItestRefGnrcAltDualDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltDualDualObject<TRef> AsRefGnrcAltDualDual { get; set; }
}

public class testAltGnrcAltDualDual
  : ItestAltGnrcAltDualDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltDualDualObject AsAltGnrcAltDualDual { get; set; }
}

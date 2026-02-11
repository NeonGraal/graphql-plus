//HintName: test_generic-alt-simple+Dual_Impl.gen.cs
// Generated from generic-alt-simple+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public class testGnrcAltSmplDual
  : ItestGnrcAltSmplDual
{
  public ItestRefGnrcAltSmplDual<string> AsRefGnrcAltSmplDual { get; set; }
  public ItestGnrcAltSmplDualObject AsGnrcAltSmplDual { get; set; }
}

public class testRefGnrcAltSmplDual<TRef>
  : ItestRefGnrcAltSmplDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltSmplDualObject AsRefGnrcAltSmplDual { get; set; }
}

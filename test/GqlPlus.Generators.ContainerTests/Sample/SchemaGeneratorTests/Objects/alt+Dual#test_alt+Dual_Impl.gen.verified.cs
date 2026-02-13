//HintName: test_alt+Dual_Impl.gen.cs
// Generated from alt+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public class testAltDual
  : ItestAltDual
{
  public ItestAltAltDual AsAltAltDual { get; set; }
  public ItestAltDualObject AsAltDual { get; set; }
}

public class testAltAltDual
  : ItestAltAltDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltDualObject AsAltAltDual { get; set; }
}

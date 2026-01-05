//HintName: test_alt+Dual_Impl.gen.cs
// Generated from alt+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public class testAltDual
  : ItestAltDual
{
  public testAltAltDual AsAltAltDual { get; set; }
  public testAltDual AltDual { get; set; }
}

public class testAltAltDual
  : ItestAltAltDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltAltDual AltAltDual { get; set; }
}

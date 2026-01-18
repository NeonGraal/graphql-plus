//HintName: test_alt-mod-Boolean+Dual_Impl.gen.cs
// Generated from alt-mod-Boolean+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public class testAltModBoolDual
  : ItestAltModBoolDual
{
  public IDictionary<testBoolean, testAltAltModBoolDual> AsAltAltModBoolDual { get; set; }
  public testAltModBoolDual AltModBoolDual { get; set; }
}

public class testAltAltModBoolDual
  : ItestAltAltModBoolDual
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltAltModBoolDual AltAltModBoolDual { get; set; }
}

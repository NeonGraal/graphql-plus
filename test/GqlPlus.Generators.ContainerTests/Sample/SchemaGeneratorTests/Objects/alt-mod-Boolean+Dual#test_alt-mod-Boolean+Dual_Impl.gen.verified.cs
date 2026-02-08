//HintName: test_alt-mod-Boolean+Dual_Impl.gen.cs
// Generated from alt-mod-Boolean+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public class testAltModBoolDual
  : ItestAltModBoolDual
{
  public IDictionary<testBoolean, ItestAltAltModBoolDual> AsAltAltModBoolDual { get; set; }
  public ItestAltModBoolDualObject AsAltModBoolDual { get; set; }
}

public class testAltAltModBoolDual
  : ItestAltAltModBoolDual
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltAltModBoolDualObject AsAltAltModBoolDual { get; set; }
}

//HintName: test_alt-mod-Boolean+Dual_Intf.gen.cs
// Generated from alt-mod-Boolean+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public interface ItestAltModBoolDual
{
  public IDictionary<testBoolean, testAltAltModBoolDual> AsAltAltModBoolDual { get; set; }
  public testAltModBoolDual AltModBoolDual { get; set; }
}

public interface ItestAltModBoolDualField
{
}

public interface ItestAltAltModBoolDual
{
  public testString AsString { get; set; }
  public testAltAltModBoolDual AltAltModBoolDual { get; set; }
}

public interface ItestAltAltModBoolDualField
{
  public testNumber alt { get; set; }
}

//HintName: test_alt-mod-Boolean+Dual_Intf.gen.cs
// Generated from alt-mod-Boolean+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public interface ItestAltModBoolDual
{
  public IDictionary<testBoolean, ItestAltAltModBoolDual> AsAltAltModBoolDual { get; set; }
}

public interface ItestAltModBoolDualObject
{
}

public interface ItestAltAltModBoolDual
{
  public ItestString AsString { get; set; }
}

public interface ItestAltAltModBoolDualObject
{
  public ItestNumber Alt { get; set; }
}

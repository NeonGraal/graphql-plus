//HintName: test_alt-mod-Boolean+Dual_Intf.gen.cs
// Generated from alt-mod-Boolean+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public interface ItestAltModBoolDual
{
  IDictionary<testBoolean, ItestAltAltModBoolDual> AsAltAltModBoolDual { get; }
  ItestAltModBoolDualObject AsAltModBoolDual { get; }
}

public interface ItestAltModBoolDualObject
{
}

public interface ItestAltAltModBoolDual
{
  string AsString { get; }
  ItestAltAltModBoolDualObject AsAltAltModBoolDual { get; }
}

public interface ItestAltAltModBoolDualObject
{
  decimal Alt { get; }
}

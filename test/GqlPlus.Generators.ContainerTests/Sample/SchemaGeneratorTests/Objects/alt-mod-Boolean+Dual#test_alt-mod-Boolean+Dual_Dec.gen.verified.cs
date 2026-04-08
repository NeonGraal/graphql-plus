//HintName: test_alt-mod-Boolean+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

public interface ItestAltModBoolDual
  // No Base because it's Class
{
  IDictionary<bool, ItestAltAltModBoolDual>? AsAltAltModBoolDual { get; }
  ItestAltModBoolDualObject? As_AltModBoolDual { get; }
}

public interface ItestAltModBoolDualObject
  // No Base because it's Class
{
}

public interface ItestAltAltModBoolDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltModBoolDualObject? As_AltAltModBoolDual { get; }
}

public interface ItestAltAltModBoolDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}

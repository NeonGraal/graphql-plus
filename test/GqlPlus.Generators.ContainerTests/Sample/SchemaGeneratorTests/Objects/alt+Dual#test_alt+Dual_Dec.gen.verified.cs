//HintName: test_alt+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public interface ItestAltDual
  // No Base because it's Class
{
  ItestAltAltDual? AsAltAltDual { get; }
  ItestAltDualObject? As_AltDual { get; }
}

public interface ItestAltDualObject
  // No Base because it's Class
{
}

public interface ItestAltAltDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltAltDualObject? As_AltAltDual { get; }
}

public interface ItestAltAltDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}

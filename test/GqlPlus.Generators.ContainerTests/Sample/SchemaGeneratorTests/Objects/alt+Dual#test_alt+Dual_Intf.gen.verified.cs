//HintName: test_alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public interface ItestAltDual
  : IGqlpModelImplementationBase
{
  ItestAltAltDual? AsAltAltDual { get; }
  ItestAltDualObject? As_AltDual { get; }
}

public interface ItestAltDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltAltDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltAltDualObject? As_AltAltDual { get; }
}

public interface ItestAltAltDualObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}

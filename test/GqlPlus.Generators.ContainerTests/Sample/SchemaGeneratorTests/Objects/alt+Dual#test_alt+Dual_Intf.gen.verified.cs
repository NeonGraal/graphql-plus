//HintName: test_alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

public interface ItestAltDual
  : IGqlpInterfaceBase
{
  ItestAltAltDual? AsAltAltDual { get; }
  ItestAltDualObject? As_AltDual { get; }
}

public interface ItestAltDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltDualObject? As_AltAltDual { get; }
}

public interface ItestAltAltDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

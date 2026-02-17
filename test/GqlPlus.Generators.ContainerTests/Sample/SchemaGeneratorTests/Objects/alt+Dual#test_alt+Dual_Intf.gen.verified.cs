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
  ItestAltAltDual AsAltAltDual { get; }
  ItestAltDualObject AsAltDual { get; }
}

public interface ItestAltDualObject
{
}

public interface ItestAltAltDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltAltDualObject AsAltAltDual { get; }
}

public interface ItestAltAltDualObject
{
  decimal Alt { get; }
}

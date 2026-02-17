//HintName: test_alt-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

public interface ItestAltDualDual
  : IGqlpModelImplementationBase
{
  ItestObjDualAltDualDual AsObjDualAltDualDual { get; }
  ItestAltDualDualObject AsAltDualDual { get; }
}

public interface ItestAltDualDualObject
{
}

public interface ItestObjDualAltDualDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestObjDualAltDualDualObject AsObjDualAltDualDual { get; }
}

public interface ItestObjDualAltDualDualObject
{
  decimal Alt { get; }
}

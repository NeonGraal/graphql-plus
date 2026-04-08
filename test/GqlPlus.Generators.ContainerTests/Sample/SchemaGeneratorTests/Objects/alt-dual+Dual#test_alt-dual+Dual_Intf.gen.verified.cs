//HintName: test_alt-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

public interface ItestAltDualDual
  : IGqlpInterfaceBase
{
  ItestObjDualAltDualDual? AsObjDualAltDualDual { get; }
  ItestAltDualDualObject? As_AltDualDual { get; }
}

public interface ItestAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjDualAltDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestObjDualAltDualDualObject? As_ObjDualAltDualDual { get; }
}

public interface ItestObjDualAltDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

//HintName: test_alt-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

public interface ItestAltDualOutp
  : IGqlpInterfaceBase
{
  ItestObjDualAltDualOutp? AsObjDualAltDualOutp { get; }
  ItestAltDualOutpObject? As_AltDualOutp { get; }
}

public interface ItestAltDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjDualAltDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestObjDualAltDualOutpObject? As_ObjDualAltDualOutp { get; }
}

public interface ItestObjDualAltDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

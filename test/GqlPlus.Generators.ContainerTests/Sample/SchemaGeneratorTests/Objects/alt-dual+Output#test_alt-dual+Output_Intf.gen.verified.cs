//HintName: test_alt-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

public interface ItestAltDualOutp
  : IGqlpModelImplementationBase
{
  ItestObjDualAltDualOutp? AsObjDualAltDualOutp { get; }
  ItestAltDualOutpObject? As_AltDualOutp { get; }
}

public interface ItestAltDualOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjDualAltDualOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestObjDualAltDualOutpObject? As_ObjDualAltDualOutp { get; }
}

public interface ItestObjDualAltDualOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}

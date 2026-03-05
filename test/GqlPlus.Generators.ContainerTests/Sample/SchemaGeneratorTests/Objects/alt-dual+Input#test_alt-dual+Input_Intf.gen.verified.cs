//HintName: test_alt-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public interface ItestAltDualInp
  : IGqlpModelImplementationBase
{
  ItestObjDualAltDualInp? AsObjDualAltDualInp { get; }
  ItestAltDualInpObject? As_AltDualInp { get; }
}

public interface ItestAltDualInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjDualAltDualInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestObjDualAltDualInpObject? As_ObjDualAltDualInp { get; }
}

public interface ItestObjDualAltDualInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}

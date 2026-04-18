//HintName: test_alt-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public interface ItestAltDualInp
  : IGqlpInterfaceBase
{
  ItestObjDualAltDualInp? AsObjDualAltDualInp { get; }
  ItestAltDualInpObject? As_AltDualInp { get; }
}

public interface ItestAltDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjDualAltDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestObjDualAltDualInpObject? As_ObjDualAltDualInp { get; }
}

public interface ItestObjDualAltDualInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

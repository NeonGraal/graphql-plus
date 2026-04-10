//HintName: test_object-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  ItestObjPrntDualObject? As_ObjPrntDual { get; }
}

public interface ItestObjPrntDualObject
  : ItestRefObjPrntDualObject
{
}

public interface ItestRefObjPrntDual
  : IGqlpInterfaceBase
{
  ItestRefObjPrntDualObject? As_RefObjPrntDual { get; }
}

public interface ItestRefObjPrntDualObject
  : IGqlpInterfaceBase
{
}

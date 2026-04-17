//HintName: test_object-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Input;

public interface ItestObjPrntInp
  : ItestRefObjPrntInp
{
  ItestObjPrntInpObject? As_ObjPrntInp { get; }
}

public interface ItestObjPrntInpObject
  : ItestRefObjPrntInpObject
{
}

public interface ItestRefObjPrntInp
  : IGqlpInterfaceBase
{
  ItestRefObjPrntInpObject? As_RefObjPrntInp { get; }
}

public interface ItestRefObjPrntInpObject
  : IGqlpInterfaceBase
{
}

//HintName: test_object-field+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Output;

public interface ItestObjFieldOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldOutpObject? As_ObjFieldOutp { get; }
}

public interface ItestObjFieldOutpObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldOutp Field { get; }
}

public interface ItestFldObjFieldOutp
  : IGqlpInterfaceBase
{
  ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; }
}

public interface ItestFldObjFieldOutpObject
  : IGqlpInterfaceBase
{
}

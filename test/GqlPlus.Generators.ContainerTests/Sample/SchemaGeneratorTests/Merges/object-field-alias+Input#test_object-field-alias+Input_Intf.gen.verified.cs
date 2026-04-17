//HintName: test_object-field-alias+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

public interface ItestObjFieldAliasInp
  : IGqlpInterfaceBase
{
  ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; }
}

public interface ItestObjFieldAliasInpObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasInp Field { get; }
}

public interface ItestFldObjFieldAliasInp
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; }
}

public interface ItestFldObjFieldAliasInpObject
  : IGqlpInterfaceBase
{
}

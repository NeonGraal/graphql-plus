//HintName: test_object-field-enum-alias+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

public interface ItestObjFieldEnumAliasInp
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumAliasInpObject? As_ObjFieldEnumAliasInp { get; }
}

public interface ItestObjFieldEnumAliasInpObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

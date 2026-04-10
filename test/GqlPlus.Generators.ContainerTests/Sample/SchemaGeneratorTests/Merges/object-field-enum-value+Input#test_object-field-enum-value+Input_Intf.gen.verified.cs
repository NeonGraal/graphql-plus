//HintName: test_object-field-enum-value+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Input;

public interface ItestObjFieldEnumValueInp
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumValueInpObject? As_ObjFieldEnumValueInp { get; }
}

public interface ItestObjFieldEnumValueInpObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

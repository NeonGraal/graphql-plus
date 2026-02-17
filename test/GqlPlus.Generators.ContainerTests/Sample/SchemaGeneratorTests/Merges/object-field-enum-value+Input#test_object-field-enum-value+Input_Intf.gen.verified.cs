//HintName: test_object-field-enum-value+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Input;

public interface ItestObjFieldEnumValueInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueInpObject AsObjFieldEnumValueInp { get; }
}

public interface ItestObjFieldEnumValueInpObject
{
  bool Field { get; }
}

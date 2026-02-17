//HintName: test_object-field-enum-alias+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

public interface ItestObjFieldEnumAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumAliasInpObject AsObjFieldEnumAliasInp { get; }
}

public interface ItestObjFieldEnumAliasInpObject
{
  bool Field { get; }
}

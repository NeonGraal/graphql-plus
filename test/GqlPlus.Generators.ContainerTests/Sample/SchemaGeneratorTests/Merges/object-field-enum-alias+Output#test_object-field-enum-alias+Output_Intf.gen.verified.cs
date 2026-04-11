//HintName: test_object-field-enum-alias+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Output;

public interface ItestObjFieldEnumAliasOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumAliasOutpObject? As_ObjFieldEnumAliasOutp { get; }
}

public interface ItestObjFieldEnumAliasOutpObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

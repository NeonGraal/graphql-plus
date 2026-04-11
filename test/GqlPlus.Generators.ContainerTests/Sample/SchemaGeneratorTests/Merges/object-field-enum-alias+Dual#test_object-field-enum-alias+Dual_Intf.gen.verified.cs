//HintName: test_object-field-enum-alias+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Dual;

public interface ItestObjFieldEnumAliasDual
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumAliasDualObject? As_ObjFieldEnumAliasDual { get; }
}

public interface ItestObjFieldEnumAliasDualObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

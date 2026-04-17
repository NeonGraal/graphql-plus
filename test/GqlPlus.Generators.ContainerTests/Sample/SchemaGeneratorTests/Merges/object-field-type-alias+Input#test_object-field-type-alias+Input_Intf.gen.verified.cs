//HintName: test_object-field-type-alias+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

public interface ItestObjFieldTypeAliasInp
  : IGqlpInterfaceBase
{
  ItestObjFieldTypeAliasInpObject? As_ObjFieldTypeAliasInp { get; }
}

public interface ItestObjFieldTypeAliasInpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

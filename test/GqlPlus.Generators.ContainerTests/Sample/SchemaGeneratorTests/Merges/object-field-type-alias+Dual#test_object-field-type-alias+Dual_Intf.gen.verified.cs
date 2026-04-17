//HintName: test_object-field-type-alias+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Dual;

public interface ItestObjFieldTypeAliasDual
  : IGqlpInterfaceBase
{
  ItestObjFieldTypeAliasDualObject? As_ObjFieldTypeAliasDual { get; }
}

public interface ItestObjFieldTypeAliasDualObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

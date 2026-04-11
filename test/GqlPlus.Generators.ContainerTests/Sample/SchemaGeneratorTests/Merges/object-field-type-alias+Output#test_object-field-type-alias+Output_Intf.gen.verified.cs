//HintName: test_object-field-type-alias+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Output;

public interface ItestObjFieldTypeAliasOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldTypeAliasOutpObject? As_ObjFieldTypeAliasOutp { get; }
}

public interface ItestObjFieldTypeAliasOutpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

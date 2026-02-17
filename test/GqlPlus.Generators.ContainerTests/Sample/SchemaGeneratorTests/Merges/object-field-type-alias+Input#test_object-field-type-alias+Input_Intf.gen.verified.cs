//HintName: test_object-field-type-alias+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

public interface ItestObjFieldTypeAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasInpObject AsObjFieldTypeAliasInp { get; }
}

public interface ItestObjFieldTypeAliasInpObject
{
  string Field { get; }
}

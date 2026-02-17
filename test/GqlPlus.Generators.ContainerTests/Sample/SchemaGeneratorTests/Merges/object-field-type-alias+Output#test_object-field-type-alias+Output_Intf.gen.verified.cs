//HintName: test_object-field-type-alias+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Output;

public interface ItestObjFieldTypeAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasOutpObject AsObjFieldTypeAliasOutp { get; }
}

public interface ItestObjFieldTypeAliasOutpObject
{
  string Field { get; }
}

//HintName: test_object-field-enum-value+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Output;

public interface ItestObjFieldEnumValueOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueOutpObject? As_ObjFieldEnumValueOutp { get; }
}

public interface ItestObjFieldEnumValueOutpObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

//HintName: test_object-field-enum-value+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Dual;

public interface ItestObjFieldEnumValueDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueDualObject? As_ObjFieldEnumValueDual { get; }
}

public interface ItestObjFieldEnumValueDualObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

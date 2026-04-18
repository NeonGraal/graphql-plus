//HintName: test_field-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

public interface ItestFieldEnumDual
  : IGqlpInterfaceBase
{
  ItestFieldEnumDualObject? As_FieldEnumDual { get; }
}

public interface ItestFieldEnumDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumDual Field { get; }
}

public enum testEnumFieldEnumDual
{
  fieldEnumDual,
}

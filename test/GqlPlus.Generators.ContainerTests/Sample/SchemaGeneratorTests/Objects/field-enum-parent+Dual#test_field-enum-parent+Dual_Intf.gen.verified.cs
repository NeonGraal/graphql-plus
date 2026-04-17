//HintName: test_field-enum-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

public interface ItestFieldEnumPrntDual
  : IGqlpInterfaceBase
{
  ItestFieldEnumPrntDualObject? As_FieldEnumPrntDual { get; }
}

public interface ItestFieldEnumPrntDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumPrntDual Field { get; }
}

public enum testEnumFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual = testPrntFieldEnumPrntDual.prnt_fieldEnumPrntDual,
  fieldEnumPrntDual,
}

public enum testPrntFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual,
}

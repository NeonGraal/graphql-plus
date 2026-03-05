//HintName: test_field-enum-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

public interface ItestFieldEnumPrntDual
  : IGqlpModelImplementationBase
{
  ItestFieldEnumPrntDualObject? As_FieldEnumPrntDual { get; }
}

public interface ItestFieldEnumPrntDualObject
  : IGqlpModelImplementationBase
{
  testEnumFieldEnumPrntDual Field { get; }
}

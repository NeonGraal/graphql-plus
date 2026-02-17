//HintName: test_field-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

public interface ItestFieldEnumDual
  : IGqlpModelImplementationBase
{
  ItestFieldEnumDualObject AsFieldEnumDual { get; }
}

public interface ItestFieldEnumDualObject
{
  testEnumFieldEnumDual Field { get; }
}

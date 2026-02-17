//HintName: test_field-enum-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

public interface ItestFieldEnumPrntInp
  : IGqlpModelImplementationBase
{
  ItestFieldEnumPrntInpObject AsFieldEnumPrntInp { get; }
}

public interface ItestFieldEnumPrntInpObject
{
  testEnumFieldEnumPrntInp Field { get; }
}

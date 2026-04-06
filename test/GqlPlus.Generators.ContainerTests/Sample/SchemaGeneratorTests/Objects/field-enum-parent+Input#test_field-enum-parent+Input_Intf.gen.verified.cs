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
  ItestFieldEnumPrntInpObject? As_FieldEnumPrntInp { get; }
}

public interface ItestFieldEnumPrntInpObject
  : IGqlpModelImplementationBase
{
  testEnumFieldEnumPrntInp Field { get; }
}

public enum testEnumFieldEnumPrntInp
{
  prnt_fieldEnumPrntInp = testPrntFieldEnumPrntInp.prnt_fieldEnumPrntInp,
  fieldEnumPrntInp,
}

public enum testPrntFieldEnumPrntInp
{
  prnt_fieldEnumPrntInp,
}

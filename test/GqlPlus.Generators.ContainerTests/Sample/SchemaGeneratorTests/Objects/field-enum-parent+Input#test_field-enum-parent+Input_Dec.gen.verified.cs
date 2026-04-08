//HintName: test_field-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

public interface ItestFieldEnumPrntInp
  // No Base because it's Class
{
  ItestFieldEnumPrntInpObject? As_FieldEnumPrntInp { get; }
}

public interface ItestFieldEnumPrntInpObject
  // No Base because it's Class
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

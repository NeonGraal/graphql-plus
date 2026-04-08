//HintName: test_field-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

public interface ItestFieldEnumPrntOutp
  // No Base because it's Class
{
  ItestFieldEnumPrntOutpObject? As_FieldEnumPrntOutp { get; }
}

public interface ItestFieldEnumPrntOutpObject
  // No Base because it's Class
{
  testEnumFieldEnumPrntOutp Field { get; }
}

public enum testEnumFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp = testPrntFieldEnumPrntOutp.prnt_fieldEnumPrntOutp,
  fieldEnumPrntOutp,
}

public enum testPrntFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp,
}

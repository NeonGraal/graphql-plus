//HintName: test_field-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

internal class testFieldEnumPrntInpDecoder
{
  public testEnumFieldEnumPrntInp Field { get; set; }
}

internal class testEnumFieldEnumPrntInpDecoder
{
  public string prnt_fieldEnumPrntInp { get; set; }
  public string fieldEnumPrntInp { get; set; }
}

internal class testPrntFieldEnumPrntInpDecoder
{
  public string prnt_fieldEnumPrntInp { get; set; }
}

internal static class test_field_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntInpObject>(r => new testFieldEnumPrntInpDecoder(r))
      .AddDecoder<testEnumFieldEnumPrntInp>(_ => new testEnumFieldEnumPrntInpDecoder())
      .AddDecoder<testPrntFieldEnumPrntInp>(_ => new testPrntFieldEnumPrntInpDecoder());
}

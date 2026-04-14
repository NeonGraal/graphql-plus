//HintName: test_field-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

internal class testFieldEnumPrntOutpDecoder
{
  public testEnumFieldEnumPrntOutp Field { get; set; }
}

internal class testEnumFieldEnumPrntOutpDecoder
{
  public string prnt_fieldEnumPrntOutp { get; set; }
  public string fieldEnumPrntOutp { get; set; }
}

internal class testPrntFieldEnumPrntOutpDecoder
{
  public string prnt_fieldEnumPrntOutp { get; set; }
}

internal static class test_field_enum_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntOutpObject>(r => new testFieldEnumPrntOutpDecoder(r))
      .AddDecoder<testEnumFieldEnumPrntOutp>(_ => new testEnumFieldEnumPrntOutpDecoder())
      .AddDecoder<testPrntFieldEnumPrntOutp>(_ => new testPrntFieldEnumPrntOutpDecoder());
}

//HintName: test_field-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

internal class testEnumFieldEnumPrntOutpDecoder : NullDecoder<testEnumFieldEnumPrntOutp>
{
  public string prnt_fieldEnumPrntOutp { get; set; } = default!;
  public string fieldEnumPrntOutp { get; set; } = default!;

  internal static testEnumFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpDecoder : NullDecoder<testPrntFieldEnumPrntOutp>
{
  public string prnt_fieldEnumPrntOutp { get; set; } = default!;

  internal static testPrntFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldEnumPrntOutp>(testEnumFieldEnumPrntOutpDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntOutp>(testPrntFieldEnumPrntOutpDecoder.Factory);
}

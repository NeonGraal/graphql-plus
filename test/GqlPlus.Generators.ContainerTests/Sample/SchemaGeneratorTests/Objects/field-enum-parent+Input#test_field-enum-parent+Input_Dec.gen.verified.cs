//HintName: test_field-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

internal class testFieldEnumPrntInpDecoder : NullDecoder<ItestFieldEnumPrntInpObject>
{
  public testEnumFieldEnumPrntInp Field { get; set; } = default!;

  internal static testFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntInpDecoder : NullDecoder<testEnumFieldEnumPrntInp>
{
  public string prnt_fieldEnumPrntInp { get; set; } = default!;
  public string fieldEnumPrntInp { get; set; } = default!;

  internal static testEnumFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpDecoder : NullDecoder<testPrntFieldEnumPrntInp>
{
  public string prnt_fieldEnumPrntInp { get; set; } = default!;

  internal static testPrntFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntInpObject>(testFieldEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntInp>(testEnumFieldEnumPrntInpDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntInp>(testPrntFieldEnumPrntInpDecoder.Factory);
}

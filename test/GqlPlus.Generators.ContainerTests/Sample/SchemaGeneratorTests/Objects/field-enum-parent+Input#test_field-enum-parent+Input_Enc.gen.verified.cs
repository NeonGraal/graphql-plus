//HintName: test_field-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

internal class testEnumFieldEnumPrntInpEncoder : IEncoder<testEnumFieldEnumPrntInp>
{
  public Structured Encode(testEnumFieldEnumPrntInp input)
    => input.EncodeEnum("EnumFieldEnumPrntInp");

  internal static testEnumFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpEncoder : IEncoder<testPrntFieldEnumPrntInp>
{
  public Structured Encode(testPrntFieldEnumPrntInp input)
    => input.EncodeEnum("PrntFieldEnumPrntInp");

  internal static testPrntFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_enum_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_enum_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumFieldEnumPrntInp>(testEnumFieldEnumPrntInpEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntInp>(testPrntFieldEnumPrntInpEncoder.Factory);
}

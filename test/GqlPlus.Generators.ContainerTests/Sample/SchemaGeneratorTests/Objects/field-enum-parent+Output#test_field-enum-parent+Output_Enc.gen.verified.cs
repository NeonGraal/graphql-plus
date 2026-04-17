//HintName: test_field-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

internal class testFieldEnumPrntOutpEncoder : IEncoder<ItestFieldEnumPrntOutpObject>
{
  public Structured Encode(ItestFieldEnumPrntOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntOutpEncoder : IEncoder<testEnumFieldEnumPrntOutp>
{
  public Structured Encode(testEnumFieldEnumPrntOutp input)
    => new(input.ToString(), "_EnumFieldEnumPrntOutp");

  internal static testEnumFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpEncoder : IEncoder<testPrntFieldEnumPrntOutp>
{
  public Structured Encode(testPrntFieldEnumPrntOutp input)
    => new(input.ToString(), "_PrntFieldEnumPrntOutp");

  internal static testPrntFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_enum_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_enum_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldEnumPrntOutpObject>(testFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntOutp>(testEnumFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntOutp>(testPrntFieldEnumPrntOutpEncoder.Factory);
}

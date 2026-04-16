//HintName: test_field-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

internal class testFieldEnumOutpEncoder : IEncoder<ItestFieldEnumOutpObject>
{
  public Structured Encode(ItestFieldEnumOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumOutpEncoder : IEncoder<testEnumFieldEnumOutp>
{
  public Structured Encode(testEnumFieldEnumOutp input)
    => new(input.ToString(), "_EnumFieldEnumOutp");

  internal static testEnumFieldEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldEnumOutpObject>(testFieldEnumOutpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumOutp>(testEnumFieldEnumOutpEncoder.Factory);
}

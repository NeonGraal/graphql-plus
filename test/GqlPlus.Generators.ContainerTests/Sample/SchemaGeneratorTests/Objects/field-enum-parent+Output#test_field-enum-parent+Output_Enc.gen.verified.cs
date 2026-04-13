//HintName: test_field-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

internal class testFieldEnumPrntOutpEncoder : IEncoder<ItestFieldEnumPrntOutpObject>
{
  public Structured Encode(ItestFieldEnumPrntOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumPrntOutpEncoder : IEncoder<testEnumFieldEnumPrntOutp>
{
  public Structured Encode(testEnumFieldEnumPrntOutp input)
    => new(input.ToString(), "_EnumFieldEnumPrntOutp");
}

internal class testPrntFieldEnumPrntOutpEncoder : IEncoder<testPrntFieldEnumPrntOutp>
{
  public Structured Encode(testPrntFieldEnumPrntOutp input)
    => new(input.ToString(), "_PrntFieldEnumPrntOutp");
}

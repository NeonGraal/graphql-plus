//HintName: test_field-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

internal class testFieldEnumPrntInpEncoder : IEncoder<ItestFieldEnumPrntInpObject>
{
  public Structured Encode(ItestFieldEnumPrntInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumPrntInpEncoder : IEncoder<testEnumFieldEnumPrntInp>
{
  public Structured Encode(testEnumFieldEnumPrntInp input)
    => new(input.ToString(), "_EnumFieldEnumPrntInp");
}

internal class testPrntFieldEnumPrntInpEncoder : IEncoder<testPrntFieldEnumPrntInp>
{
  public Structured Encode(testPrntFieldEnumPrntInp input)
    => new(input.ToString(), "_PrntFieldEnumPrntInp");
}

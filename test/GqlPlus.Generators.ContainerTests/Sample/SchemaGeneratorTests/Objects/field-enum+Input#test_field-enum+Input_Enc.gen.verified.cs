//HintName: test_field-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

internal class testFieldEnumInpEncoder : IEncoder<ItestFieldEnumInpObject>
{
  public Structured Encode(ItestFieldEnumInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumInpEncoder : IEncoder<testEnumFieldEnumInp>
{
  public Structured Encode(testEnumFieldEnumInp input)
    => new(input.ToString(), "_EnumFieldEnumInp");
}

//HintName: test_field-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

internal class testFieldValueInpEncoder : IEncoder<ItestFieldValueInpObject>
{
  public Structured Encode(ItestFieldValueInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldValueInpEncoder : IEncoder<testEnumFieldValueInp>
{
  public Structured Encode(testEnumFieldValueInp input)
    => new(input.ToString(), "_EnumFieldValueInp");
}

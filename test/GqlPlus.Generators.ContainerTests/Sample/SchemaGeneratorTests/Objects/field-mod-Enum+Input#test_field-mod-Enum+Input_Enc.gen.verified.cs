//HintName: test_field-mod-Enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

internal class testFieldModEnumInpEncoder : IEncoder<ItestFieldModEnumInpObject>
{
  public Structured Encode(ItestFieldModEnumInpObject input)
    => Structured.Empty();
}

internal class testEnumFieldModEnumInpEncoder : IEncoder<testEnumFieldModEnumInp>
{
  public Structured Encode(testEnumFieldModEnumInp input)
    => new(input.ToString(), "_EnumFieldModEnumInp");
}

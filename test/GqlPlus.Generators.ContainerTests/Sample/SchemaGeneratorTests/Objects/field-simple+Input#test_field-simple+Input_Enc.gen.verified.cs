//HintName: test_field-simple+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Input;

internal class testFieldSmplInpEncoder : IEncoder<ItestFieldSmplInpObject>
{
  public Structured Encode(ItestFieldSmplInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

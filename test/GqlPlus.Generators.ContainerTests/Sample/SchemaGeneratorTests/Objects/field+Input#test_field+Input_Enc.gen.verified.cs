//HintName: test_field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Input;

internal class testFieldInpEncoder : IEncoder<ItestFieldInpObject>
{
  public Structured Encode(ItestFieldInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

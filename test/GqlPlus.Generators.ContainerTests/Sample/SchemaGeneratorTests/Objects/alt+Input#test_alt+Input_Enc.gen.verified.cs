//HintName: test_alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

internal class testAltInpEncoder : IEncoder<ItestAltInpObject>
{
  public Structured Encode(ItestAltInpObject input)
    => Structured.Empty();
}

internal class testAltAltInpEncoder : IEncoder<ItestAltAltInpObject>
{
  public Structured Encode(ItestAltAltInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

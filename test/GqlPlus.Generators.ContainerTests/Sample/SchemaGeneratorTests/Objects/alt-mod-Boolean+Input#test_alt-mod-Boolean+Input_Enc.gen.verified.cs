//HintName: test_alt-mod-Boolean+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

internal class testAltModBoolInpEncoder : IEncoder<ItestAltModBoolInpObject>
{
  public Structured Encode(ItestAltModBoolInpObject input)
    => Structured.Empty();
}

internal class testAltAltModBoolInpEncoder : IEncoder<ItestAltAltModBoolInpObject>
{
  public Structured Encode(ItestAltAltModBoolInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

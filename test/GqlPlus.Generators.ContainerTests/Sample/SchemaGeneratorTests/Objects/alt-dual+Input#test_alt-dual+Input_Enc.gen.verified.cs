//HintName: test_alt-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

internal class testAltDualInpEncoder : IEncoder<ItestAltDualInpObject>
{
  public Structured Encode(ItestAltDualInpObject input)
    => Structured.Empty();
}

internal class testObjDualAltDualInpEncoder : IEncoder<ItestObjDualAltDualInpObject>
{
  public Structured Encode(ItestObjDualAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

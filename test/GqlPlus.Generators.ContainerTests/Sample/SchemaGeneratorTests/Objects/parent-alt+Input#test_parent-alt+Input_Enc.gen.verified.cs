//HintName: test_parent-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

internal class testPrntAltInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltInpObject>
{
  private readonly IEncoder<ItestRefPrntAltInpObject> _itestRefPrntAltInp = encoders.EncoderFor<ItestRefPrntAltInpObject>();
  public Structured Encode(ItestPrntAltInpObject input)
    => _itestRefPrntAltInp.Encode(input);
}

internal class testRefPrntAltInpEncoder : IEncoder<ItestRefPrntAltInpObject>
{
  public Structured Encode(ItestRefPrntAltInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

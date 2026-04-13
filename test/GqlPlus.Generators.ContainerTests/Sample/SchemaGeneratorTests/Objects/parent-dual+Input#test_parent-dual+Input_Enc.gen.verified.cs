//HintName: test_parent-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

internal class testPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualInpObject>
{
  private readonly IEncoder<ItestRefPrntDualInpObject> _itestRefPrntDualInp = encoders.EncoderFor<ItestRefPrntDualInpObject>();
  public Structured Encode(ItestPrntDualInpObject input)
    => _itestRefPrntDualInp.Encode(input);
}

internal class testRefPrntDualInpEncoder : IEncoder<ItestRefPrntDualInpObject>
{
  public Structured Encode(ItestRefPrntDualInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

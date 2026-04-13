//HintName: test_parent-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

internal class testPrntDescrInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrInpObject>
{
  private readonly IEncoder<ItestRefPrntDescrInpObject> _itestRefPrntDescrInp = encoders.EncoderFor<ItestRefPrntDescrInpObject>();
  public Structured Encode(ItestPrntDescrInpObject input)
    => _itestRefPrntDescrInp.Encode(input);
}

internal class testRefPrntDescrInpEncoder : IEncoder<ItestRefPrntDescrInpObject>
{
  public Structured Encode(ItestRefPrntDescrInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

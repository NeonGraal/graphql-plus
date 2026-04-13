//HintName: test_object-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Input;

internal class testObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntInpObject>
{
  private readonly IEncoder<ItestRefObjPrntInpObject> _itestRefObjPrntInp = encoders.EncoderFor<ItestRefObjPrntInpObject>();
  public Structured Encode(ItestObjPrntInpObject input)
    => _itestRefObjPrntInp.Encode(input);
}

internal class testRefObjPrntInpEncoder : IEncoder<ItestRefObjPrntInpObject>
{
  public Structured Encode(ItestRefObjPrntInpObject input)
    => Structured.Empty();
}

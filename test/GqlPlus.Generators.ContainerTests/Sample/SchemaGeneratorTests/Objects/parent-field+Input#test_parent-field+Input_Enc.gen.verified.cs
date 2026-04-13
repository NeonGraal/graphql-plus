//HintName: test_parent-field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

internal class testPrntFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldInpObject>
{
  private readonly IEncoder<ItestRefPrntFieldInpObject> _itestRefPrntFieldInp = encoders.EncoderFor<ItestRefPrntFieldInpObject>();
  public Structured Encode(ItestPrntFieldInpObject input)
    => _itestRefPrntFieldInp.Encode(input)
      .Add("field", input.Field);
}

internal class testRefPrntFieldInpEncoder : IEncoder<ItestRefPrntFieldInpObject>
{
  public Structured Encode(ItestRefPrntFieldInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

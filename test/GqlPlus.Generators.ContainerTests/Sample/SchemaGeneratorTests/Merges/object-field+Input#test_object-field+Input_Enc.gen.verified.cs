//HintName: test_object-field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

internal class testObjFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldInpObject>
{
  private readonly IEncoder<ItestFldObjFieldInp> _itestFldObjFieldInp = encoders.EncoderFor<ItestFldObjFieldInp>();
  public Structured Encode(ItestObjFieldInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldInp);
}

internal class testFldObjFieldInpEncoder : IEncoder<ItestFldObjFieldInpObject>
{
  public Structured Encode(ItestFldObjFieldInpObject input)
    => Structured.Empty();
}

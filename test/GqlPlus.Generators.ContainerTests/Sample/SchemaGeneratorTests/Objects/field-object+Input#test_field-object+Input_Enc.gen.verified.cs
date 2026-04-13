//HintName: test_field-object+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

internal class testFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjInpObject>
{
  private readonly IEncoder<ItestFldFieldObjInp> _itestFldFieldObjInp = encoders.EncoderFor<ItestFldFieldObjInp>();
  public Structured Encode(ItestFieldObjInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjInp);
}

internal class testFldFieldObjInpEncoder : IEncoder<ItestFldFieldObjInpObject>
{
  public Structured Encode(ItestFldFieldObjInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

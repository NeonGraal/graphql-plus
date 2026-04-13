//HintName: test_constraint-alt-obj+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

internal class testCnstAltObjInpEncoder : IEncoder<ItestCnstAltObjInpObject>
{
  public Structured Encode(ItestCnstAltObjInpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltObjInpEncoder<TRef> : IEncoder<ItestRefCnstAltObjInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltObjInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltObjInpEncoder : IEncoder<ItestPrntCnstAltObjInpObject>
{
  public Structured Encode(ItestPrntCnstAltObjInpObject input)
    => Structured.Empty();
}

internal class testAltCnstAltObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjInpObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjInpObject> _itestPrntCnstAltObjInp = encoders.EncoderFor<ItestPrntCnstAltObjInpObject>();
  public Structured Encode(ItestAltCnstAltObjInpObject input)
    => _itestPrntCnstAltObjInp.Encode(input)
      .Add("alt", input.Alt);
}

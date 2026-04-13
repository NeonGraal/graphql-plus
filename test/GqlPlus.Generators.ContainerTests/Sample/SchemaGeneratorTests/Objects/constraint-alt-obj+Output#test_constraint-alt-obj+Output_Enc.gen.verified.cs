//HintName: test_constraint-alt-obj+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

internal class testCnstAltObjOutpEncoder : IEncoder<ItestCnstAltObjOutpObject>
{
  public Structured Encode(ItestCnstAltObjOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltObjOutpEncoder : IEncoder<ItestRefCnstAltObjOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltObjOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltObjOutpEncoder : IEncoder<ItestPrntCnstAltObjOutpObject>
{
  public Structured Encode(ItestPrntCnstAltObjOutpObject input)
    => Structured.Empty();
}

internal class testAltCnstAltObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjOutpObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjOutpObject> _itestPrntCnstAltObjOutp = encoders.EncoderFor<ItestPrntCnstAltObjOutpObject>();
  public Structured Encode(ItestAltCnstAltObjOutpObject input)
    => _itestPrntCnstAltObjOutp.Encode(input)
      .Add("alt", input.Alt);
}

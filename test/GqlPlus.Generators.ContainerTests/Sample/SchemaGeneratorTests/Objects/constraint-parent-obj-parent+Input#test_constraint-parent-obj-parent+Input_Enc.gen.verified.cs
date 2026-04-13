//HintName: test_constraint-parent-obj-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Input;

internal class testCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>> _itestRefCnstPrntObjPrntInp = encoders.EncoderFor<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>>();
  public Structured Encode(ItestCnstPrntObjPrntInpObject input)
    => _itestRefCnstPrntObjPrntInp.Encode(input);
}

internal class testRefCnstPrntObjPrntInpEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntInpEncoder : IEncoder<ItestPrntCnstPrntObjPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntInpObject input)
    => Structured.Empty();
}

internal class testAltCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntInpObject> _itestPrntCnstPrntObjPrntInp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntInpObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntInpObject input)
    => _itestPrntCnstPrntObjPrntInp.Encode(input)
      .Add("alt", input.Alt);
}

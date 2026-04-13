//HintName: test_constraint-parent-dual-grandparent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

internal class testCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>> _itestRefCnstPrntDualGrndInp = encoders.EncoderFor<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>>();
  public Structured Encode(ItestCnstPrntDualGrndInpObject input)
    => _itestRefCnstPrntDualGrndInp.Encode(input);
}

internal class testRefCnstPrntDualGrndInpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualGrndInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGrndCnstPrntDualGrndInpEncoder : IEncoder<ItestGrndCnstPrntDualGrndInpObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndInpObject input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndInpObject> _itestGrndCnstPrntDualGrndInp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndInpObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndInpObject input)
    => _itestGrndCnstPrntDualGrndInp.Encode(input);
}

internal class testAltCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndInpObject> _itestPrntCnstPrntDualGrndInp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndInpObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndInpObject input)
    => _itestPrntCnstPrntDualGrndInp.Encode(input)
      .Add("alt", input.Alt);
}

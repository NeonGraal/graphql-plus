//HintName: test_constraint-parent-obj-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

internal class testCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>> _itestRefCnstPrntObjPrntDual = encoders.EncoderFor<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>>();
  public Structured Encode(ItestCnstPrntObjPrntDualObject input)
    => _itestRefCnstPrntObjPrntDual.Encode(input);
}

internal class testRefCnstPrntObjPrntDualEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntDualEncoder : IEncoder<ItestPrntCnstPrntObjPrntDualObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntDualObject input)
    => Structured.Empty();
}

internal class testAltCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntDualObject> _itestPrntCnstPrntObjPrntDual = encoders.EncoderFor<ItestPrntCnstPrntObjPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntDualObject input)
    => _itestPrntCnstPrntObjPrntDual.Encode(input)
      .Add("alt", input.Alt);
}

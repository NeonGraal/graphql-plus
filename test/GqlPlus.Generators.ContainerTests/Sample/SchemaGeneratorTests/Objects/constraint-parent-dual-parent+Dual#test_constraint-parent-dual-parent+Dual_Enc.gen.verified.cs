//HintName: test_constraint-parent-dual-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

internal class testCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>> _itestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual> = encoders.EncoderFor<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>>();
  public Structured Encode(ItestCnstPrntDualPrntDualObject input)
    => _itestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>.Encode(input);
}

internal class testRefCnstPrntDualPrntDualEncoder : IEncoder<ItestRefCnstPrntDualPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntDualEncoder : IEncoder<ItestPrntCnstPrntDualPrntDualObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntDualObject input)
    => Structured.Empty();
}

internal class testAltCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntDualObject> _itestPrntCnstPrntDualPrntDual = encoders.EncoderFor<ItestPrntCnstPrntDualPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntDualObject input)
    => _itestPrntCnstPrntDualPrntDual.Encode(input)
      .Add("alt", input.Alt);
}

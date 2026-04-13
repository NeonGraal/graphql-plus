//HintName: test_generic-parent-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

internal class testGnrcPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>> _itestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual> = encoders.EncoderFor<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>>();
  public Structured Encode(ItestGnrcPrntDualDualObject input)
    => _itestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>.Encode(input);
}

internal class testRefGnrcPrntDualDualEncoder : IEncoder<ItestRefGnrcPrntDualDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualDualEncoder : IEncoder<ItestAltGnrcPrntDualDualObject>
{
  public Structured Encode(ItestAltGnrcPrntDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

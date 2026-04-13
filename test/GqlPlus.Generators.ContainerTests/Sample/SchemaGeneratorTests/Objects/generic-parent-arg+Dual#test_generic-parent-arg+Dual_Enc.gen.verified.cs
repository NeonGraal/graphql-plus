//HintName: test_generic-parent-arg+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

internal class testGnrcPrntArgDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgDualObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgDualObject<TType>> _itestRefGnrcPrntArgDualObject<TType> = encoders.EncoderFor<ItestRefGnrcPrntArgDualObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgDualObject<TType> input)
    => _itestRefGnrcPrntArgDualObject<TType>.Encode(input);
}

internal class testRefGnrcPrntArgDualEncoder : IEncoder<ItestRefGnrcPrntArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgDualObject<TRef> input)
    => Structured.Empty();
}

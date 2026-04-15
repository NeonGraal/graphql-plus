//HintName: test_generic-parent-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

internal class testGnrcPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>> _itestRefGnrcPrntDualOutp = encoders.EncoderFor<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>>();
  public Structured Encode(ItestGnrcPrntDualOutpObject input)
    => _itestRefGnrcPrntDualOutp.Encode(input);
}

internal class testRefGnrcPrntDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualOutpEncoder : IEncoder<ItestAltGnrcPrntDualOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal static class test_generic_parent_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntDualOutpObject>(r => new testGnrcPrntDualOutpEncoder(r))
      .AddEncoder<ItestAltGnrcPrntDualOutpObject>(_ => new testAltGnrcPrntDualOutpEncoder());
}

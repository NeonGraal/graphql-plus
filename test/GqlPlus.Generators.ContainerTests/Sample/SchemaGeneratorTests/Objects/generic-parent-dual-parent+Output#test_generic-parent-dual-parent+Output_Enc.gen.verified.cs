//HintName: test_generic-parent-dual-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

internal class testGnrcPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>> _itestRefGnrcPrntDualPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>>();
  public Structured Encode(ItestGnrcPrntDualPrntOutpObject input)
    => _itestRefGnrcPrntDualPrntOutp.Encode(input);

  internal static testGnrcPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualPrntOutpEncoder : IEncoder<ItestAltGnrcPrntDualPrntOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntDualPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_dual_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_dual_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntDualPrntOutpObject>(testGnrcPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntOutpObject>(testAltGnrcPrntDualPrntOutpEncoder.Factory);
}

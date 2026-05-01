//HintName: test_generic-parent-dual-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

internal class testGnrcPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>> _itestRefGnrcPrntDualPrntInp = encoders.EncoderFor<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>>();
  public Structured Encode(ItestGnrcPrntDualPrntInpObject input)
    => _itestRefGnrcPrntDualPrntInp.Encode(input);

  internal static testGnrcPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualPrntInpEncoder : IEncoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_dual_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_dual_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntDualPrntInpObject>(testGnrcPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntInpObject>(testAltGnrcPrntDualPrntInpEncoder.Factory);
}

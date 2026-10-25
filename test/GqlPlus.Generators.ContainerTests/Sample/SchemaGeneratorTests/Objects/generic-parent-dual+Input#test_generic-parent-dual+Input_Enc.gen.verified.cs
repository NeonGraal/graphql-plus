//HintName: test_generic-parent-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

internal class testGnrcPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualInpObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>> _itestRefGnrcPrntDualInp = encoders.EncoderFor<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>>();
  public IGqlpValue Encode(ItestGnrcPrntDualInpObject input)
    => _itestRefGnrcPrntDualInp.Encode(input);

  internal static testGnrcPrntDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualInpEncoder : IEncoder<ItestAltGnrcPrntDualInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntDualInpObject>(testGnrcPrntDualInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualInpObject>(testAltGnrcPrntDualInpEncoder.Factory);
}

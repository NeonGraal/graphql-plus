//HintName: test_generic-parent-param-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

internal class testGnrcPrntParamPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>> _itestRefGnrcPrntParamPrntDual = encoders.EncoderFor<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>>();
  public Structured Encode(ItestGnrcPrntParamPrntDualObject input)
    => _itestRefGnrcPrntParamPrntDual.Encode(input);

  internal static testGnrcPrntParamPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamPrntDualEncoder : IEncoder<ItestAltGnrcPrntParamPrntDualObject>
{
  public Structured Encode(ItestAltGnrcPrntParamPrntDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntParamPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_param_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_param_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntParamPrntDualObject>(testGnrcPrntParamPrntDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamPrntDualObject>(testAltGnrcPrntParamPrntDualEncoder.Factory);
}

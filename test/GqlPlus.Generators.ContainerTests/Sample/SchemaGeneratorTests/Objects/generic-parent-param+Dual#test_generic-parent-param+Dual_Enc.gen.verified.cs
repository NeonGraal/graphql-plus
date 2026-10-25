//HintName: test_generic-parent-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

internal class testGnrcPrntParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamDualObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>> _itestRefGnrcPrntParamDual = encoders.EncoderFor<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>>();
  public IGqlpValue Encode(ItestGnrcPrntParamDualObject input)
    => _itestRefGnrcPrntParamDual.Encode(input);

  internal static testGnrcPrntParamDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamDualEncoder : IEncoder<ItestAltGnrcPrntParamDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_param_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_param_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntParamDualObject>(testGnrcPrntParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamDualObject>(testAltGnrcPrntParamDualEncoder.Factory);
}

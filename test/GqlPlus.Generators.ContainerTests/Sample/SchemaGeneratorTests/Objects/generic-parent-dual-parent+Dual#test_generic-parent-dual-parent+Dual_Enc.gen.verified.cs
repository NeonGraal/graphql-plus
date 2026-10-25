//HintName: test_generic-parent-dual-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

internal class testGnrcPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntDualObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>> _itestRefGnrcPrntDualPrntDual = encoders.EncoderFor<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>>();
  public IGqlpValue Encode(ItestGnrcPrntDualPrntDualObject input)
    => _itestRefGnrcPrntDualPrntDual.Encode(input);

  internal static testGnrcPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualPrntDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualPrntDualEncoder : IEncoder<ItestAltGnrcPrntDualPrntDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualPrntDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_dual_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_dual_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntDualPrntDualObject>(testGnrcPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntDualObject>(testAltGnrcPrntDualPrntDualEncoder.Factory);
}

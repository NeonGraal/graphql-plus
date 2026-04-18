//HintName: test_generic-parent-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

internal class testGnrcPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>> _itestRefGnrcPrntDualDual = encoders.EncoderFor<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>>();
  public Structured Encode(ItestGnrcPrntDualDualObject input)
    => _itestRefGnrcPrntDualDual.Encode(input);

  internal static testGnrcPrntDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualDualEncoder : IEncoder<ItestAltGnrcPrntDualDualObject>
{
  public Structured Encode(ItestAltGnrcPrntDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntDualDualObject>(testGnrcPrntDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualDualObject>(testAltGnrcPrntDualDualEncoder.Factory);
}

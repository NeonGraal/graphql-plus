//HintName: test_generic-alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

internal class testGnrcAltDualDualEncoder : IEncoder<ItestGnrcAltDualDualObject>
{
  public IGqlpValue Encode(ItestGnrcAltDualDualObject input)
    => new GqlpUnit();

  internal static testGnrcAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualDualEncoder<TRef> : IEncoder<ItestRefGnrcAltDualDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltDualDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltDualDualEncoder : IEncoder<ItestAltGnrcAltDualDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltDualDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_alt_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltDualDualObject>(testGnrcAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualDualObject>(testAltGnrcAltDualDualEncoder.Factory);
}

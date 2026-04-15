//HintName: test_generic-alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

internal class testGnrcAltDualDualEncoder : IEncoder<ItestGnrcAltDualDualObject>
{
  public Structured Encode(ItestGnrcAltDualDualObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltDualDualEncoder<TRef> : IEncoder<ItestRefGnrcAltDualDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltDualDualEncoder : IEncoder<ItestAltGnrcAltDualDualObject>
{
  public Structured Encode(ItestAltGnrcAltDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal static class test_generic_alt_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltDualDualObject>(_ => new testGnrcAltDualDualEncoder())
      .AddEncoder<ItestAltGnrcAltDualDualObject>(_ => new testAltGnrcAltDualDualEncoder());
}

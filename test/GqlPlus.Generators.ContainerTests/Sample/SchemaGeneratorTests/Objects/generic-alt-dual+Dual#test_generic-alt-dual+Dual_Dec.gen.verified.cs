//HintName: test_generic-alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

internal class testGnrcAltDualDualDecoder
{
}

internal class testRefGnrcAltDualDualDecoder<TRef>
{
}

internal class testAltGnrcAltDualDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_alt_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltDualDualObject>(_ => new testGnrcAltDualDualDecoder())
      .AddDecoder<ItestAltGnrcAltDualDualObject>(r => new testAltGnrcAltDualDualDecoder(r));
}

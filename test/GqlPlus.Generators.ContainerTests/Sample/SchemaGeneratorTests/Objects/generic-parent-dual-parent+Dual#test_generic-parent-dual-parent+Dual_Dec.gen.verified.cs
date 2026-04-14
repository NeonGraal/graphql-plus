//HintName: test_generic-parent-dual-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

internal class testGnrcPrntDualPrntDualDecoder
{
}

internal class testRefGnrcPrntDualPrntDualDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_parent_dual_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntDualPrntDualObject>(_ => new testGnrcPrntDualPrntDualDecoder())
      .AddDecoder<ItestAltGnrcPrntDualPrntDualObject>(_ => new testAltGnrcPrntDualPrntDualDecoder());
}

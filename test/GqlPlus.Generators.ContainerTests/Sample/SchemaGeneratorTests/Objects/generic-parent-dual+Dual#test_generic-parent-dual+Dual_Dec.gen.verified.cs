//HintName: test_generic-parent-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

internal class testGnrcPrntDualDualDecoder
{
}

internal class testRefGnrcPrntDualDualDecoder<TRef>
{
}

internal class testAltGnrcPrntDualDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_parent_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntDualDualObject>(_ => new testGnrcPrntDualDualDecoder())
      .AddDecoder<ItestAltGnrcPrntDualDualObject>(_ => new testAltGnrcPrntDualDualDecoder());
}

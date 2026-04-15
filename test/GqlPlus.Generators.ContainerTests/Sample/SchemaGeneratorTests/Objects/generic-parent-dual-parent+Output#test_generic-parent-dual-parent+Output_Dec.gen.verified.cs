//HintName: test_generic-parent-dual-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

internal class testAltGnrcPrntDualPrntOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_parent_dual_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltGnrcPrntDualPrntOutpObject>(_ => new testAltGnrcPrntDualPrntOutpDecoder());
}

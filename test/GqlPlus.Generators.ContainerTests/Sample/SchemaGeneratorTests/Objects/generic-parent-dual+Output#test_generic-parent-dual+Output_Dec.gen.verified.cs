//HintName: test_generic-parent-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

internal class testAltGnrcPrntDualOutpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltGnrcPrntDualOutpObject>(testAltGnrcPrntDualOutpDecoder.Factory);
}

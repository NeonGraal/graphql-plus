//HintName: test_generic-alt-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

internal class testAltGnrcAltDualOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_alt_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltGnrcAltDualOutpObject>(_ => new testAltGnrcAltDualOutpDecoder());
}

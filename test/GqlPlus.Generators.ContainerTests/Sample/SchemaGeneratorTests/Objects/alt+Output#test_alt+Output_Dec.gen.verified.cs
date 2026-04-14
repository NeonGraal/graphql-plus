//HintName: test_alt+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Output;

internal class testAltOutpDecoder
{
}

internal class testAltAltOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltOutpObject>(_ => new testAltOutpDecoder())
      .AddDecoder<ItestAltAltOutpObject>(r => new testAltAltOutpDecoder(r));
}

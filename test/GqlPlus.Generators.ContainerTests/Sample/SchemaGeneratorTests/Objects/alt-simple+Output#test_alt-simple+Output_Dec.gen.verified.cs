//HintName: test_alt-simple+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Output;

internal class testAltSmplOutpDecoder
{
}

internal static class test_alt_simple_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_simple_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltSmplOutpObject>(_ => new testAltSmplOutpDecoder());
}

//HintName: test_alt-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_descr_Output;

internal class testAltDescrOutpDecoder
{
}

internal static class test_alt_descr_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_descr_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDescrOutpObject>(_ => new testAltDescrOutpDecoder());
}

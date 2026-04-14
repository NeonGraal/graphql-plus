//HintName: test_descrs_Dec.gen.cs
// Generated from {CurrentDirectory}descrs.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descrs;

internal class testDscrsDecoder
{
}

internal static class test_descrsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_descrsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDscrsObject>(_ => new testDscrsDecoder());
}

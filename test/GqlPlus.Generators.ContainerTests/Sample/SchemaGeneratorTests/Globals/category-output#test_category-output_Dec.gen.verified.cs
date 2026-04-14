//HintName: test_category-output_Dec.gen.cs
// Generated from {CurrentDirectory}category-output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output;

internal class testCtgrOutpDecoder
{
}

internal static class test_category_outputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_outputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrOutpObject>(_ => new testCtgrOutpDecoder());
}

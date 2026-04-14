//HintName: test_category_Dec.gen.cs
// Generated from {CurrentDirectory}category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category;

internal class testCtgrDecoder
{
}

internal static class test_categoryDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_categoryDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrObject>(_ => new testCtgrDecoder());
}

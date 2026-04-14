//HintName: test_category-descrs_Dec.gen.cs
// Generated from {CurrentDirectory}category-descrs.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_descrs;

internal class testCtgrDscrsDecoder
{
}

internal static class test_category_descrsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_descrsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrDscrsObject>(_ => new testCtgrDscrsDecoder());
}

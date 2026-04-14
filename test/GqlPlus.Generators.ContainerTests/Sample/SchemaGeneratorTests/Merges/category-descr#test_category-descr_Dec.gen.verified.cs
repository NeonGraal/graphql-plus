//HintName: test_category-descr_Dec.gen.cs
// Generated from {CurrentDirectory}category-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_descr;

internal class testCtgrDescrDecoder
{
}

internal static class test_category_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrDescrObject>(_ => new testCtgrDescrDecoder());
}

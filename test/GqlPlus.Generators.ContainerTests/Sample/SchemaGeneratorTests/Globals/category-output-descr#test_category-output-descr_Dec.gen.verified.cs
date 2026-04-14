//HintName: test_category-output-descr_Dec.gen.cs
// Generated from {CurrentDirectory}category-output-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_descr;

internal class testCtgrOutpDescrDecoder
{
}

internal static class test_category_output_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_output_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrOutpDescrObject>(_ => new testCtgrOutpDescrDecoder());
}

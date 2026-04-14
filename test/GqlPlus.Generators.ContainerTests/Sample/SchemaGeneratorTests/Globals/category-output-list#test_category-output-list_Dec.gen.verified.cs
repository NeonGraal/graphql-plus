//HintName: test_category-output-list_Dec.gen.cs
// Generated from {CurrentDirectory}category-output-list.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_list;

internal class testCtgrOutpListDecoder
{
}

internal static class test_category_output_listDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_output_listDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrOutpListObject>(_ => new testCtgrOutpListDecoder());
}

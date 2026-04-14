//HintName: test_category-output-dict_Dec.gen.cs
// Generated from {CurrentDirectory}category-output-dict.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_dict;

internal class testCtgrOutpDictDecoder
{
}

internal static class test_category_output_dictDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_output_dictDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrOutpDictObject>(_ => new testCtgrOutpDictDecoder());
}

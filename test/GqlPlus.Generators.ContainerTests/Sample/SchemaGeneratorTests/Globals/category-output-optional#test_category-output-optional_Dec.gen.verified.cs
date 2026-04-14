//HintName: test_category-output-optional_Dec.gen.cs
// Generated from {CurrentDirectory}category-output-optional.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_optional;

internal class testCtgrOutpOptlDecoder
{
}

internal static class test_category_output_optionalDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_output_optionalDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrOutpOptlObject>(_ => new testCtgrOutpOptlDecoder());
}

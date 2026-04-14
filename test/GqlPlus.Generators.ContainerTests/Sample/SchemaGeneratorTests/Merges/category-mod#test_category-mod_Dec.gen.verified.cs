//HintName: test_category-mod_Dec.gen.cs
// Generated from {CurrentDirectory}category-mod.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_mod;

internal class testCtgrModDecoder
{
}

internal static class test_category_modDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_modDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrModObject>(_ => new testCtgrModDecoder());
}

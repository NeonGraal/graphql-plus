//HintName: test_category-alias_Dec.gen.cs
// Generated from {CurrentDirectory}category-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_alias;

internal class testCtgrAliasDecoder
{
}

internal static class test_category_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_category_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCtgrAliasObject>(_ => new testCtgrAliasDecoder());
}

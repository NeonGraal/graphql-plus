//HintName: test_domain-alias_Dec.gen.cs
// Generated from {CurrentDirectory}domain-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_alias;

internal class testDmnAliasDecoder
{

  internal static testDmnAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnAlias>(testDmnAliasDecoder.Factory);
}

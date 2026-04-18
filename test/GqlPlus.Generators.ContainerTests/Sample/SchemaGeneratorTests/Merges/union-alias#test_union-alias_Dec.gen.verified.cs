//HintName: test_union-alias_Dec.gen.cs
// Generated from {CurrentDirectory}union-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_alias;

internal class testUnionAliasDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }

  internal static testUnionAliasDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionAlias>(testUnionAliasDecoder.Factory);
}

//HintName: test_union-alias_Dec.gen.cs
// Generated from {CurrentDirectory}union-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_alias;

internal class testUnionAliasDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

internal static class test_union_aliasDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_aliasDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionAlias>(_ => new testUnionAliasDecoder());
}

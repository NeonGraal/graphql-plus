//HintName: test_union-parent-dup_Dec.gen.cs
// Generated from {CurrentDirectory}union-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

internal class testUnionPrntDupDecoder
{
  public Number AsNumber { get; set; }

  internal static testUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDupDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_parent_dupDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_parent_dupDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionPrntDup>(testUnionPrntDupDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDup>(testPrntUnionPrntDupDecoder.Factory);
}

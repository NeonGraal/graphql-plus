//HintName: test_union-diff_Dec.gen.cs
// Generated from {CurrentDirectory}union-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_diff;

internal class testUnionDiffDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }

  internal static testUnionDiffDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionDiff>(testUnionDiffDecoder.Factory);
}

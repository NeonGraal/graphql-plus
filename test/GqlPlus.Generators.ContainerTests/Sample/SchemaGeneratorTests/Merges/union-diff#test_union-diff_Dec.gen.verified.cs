//HintName: test_union-diff_Dec.gen.cs
// Generated from {CurrentDirectory}union-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_diff;

internal class testUnionDiffDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

internal static class test_union_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionDiff>(_ => new testUnionDiffDecoder());
}

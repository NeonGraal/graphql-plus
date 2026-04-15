//HintName: test_union-same_Dec.gen.cs
// Generated from {CurrentDirectory}union-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same;

internal class testUnionSameDecoder
{
  public Boolean AsBoolean { get; set; }

  internal static testUnionSameDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_sameDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_sameDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionSame>(testUnionSameDecoder.Factory);
}

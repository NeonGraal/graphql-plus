//HintName: test_union-same-parent_Dec.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

internal class testUnionSamePrntDecoder
{
  public Boolean AsBoolean { get; set; }

  internal static testUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionSamePrntDecoder
{
  public String AsString { get; set; }

  internal static testPrntUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_same_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_same_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionSamePrnt>(testUnionSamePrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntDecoder.Factory);
}

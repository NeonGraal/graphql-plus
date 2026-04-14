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
}

internal class testPrntUnionSamePrntDecoder
{
  public String AsString { get; set; }
}

internal static class test_union_same_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_same_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionSamePrnt>(r => new testUnionSamePrntDecoder(r))
      .AddDecoder<ItestPrntUnionSamePrnt>(r => new testPrntUnionSamePrntDecoder(r));
}

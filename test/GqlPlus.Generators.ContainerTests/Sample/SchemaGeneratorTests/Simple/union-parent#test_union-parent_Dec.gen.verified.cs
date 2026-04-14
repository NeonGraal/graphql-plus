//HintName: test_union-parent_Dec.gen.cs
// Generated from {CurrentDirectory}union-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent;

internal class testUnionPrntDecoder
{
  public String AsString { get; set; }
}

internal class testPrntUnionPrntDecoder
{
  public Number AsNumber { get; set; }
}

internal static class test_union_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionPrnt>(r => new testUnionPrntDecoder(r))
      .AddDecoder<ItestPrntUnionPrnt>(r => new testPrntUnionPrntDecoder(r));
}

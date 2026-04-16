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

  internal static testUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionPrnt>(testUnionPrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrnt>(testPrntUnionPrntDecoder.Factory);
}

//HintName: test_union-descr_Dec.gen.cs
// Generated from {CurrentDirectory}union-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_descr;

internal class testUnionDescrDecoder
{
  public Number AsNumber { get; set; }
}

internal static class test_union_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionDescr>(r => new testUnionDescrDecoder(r));
}

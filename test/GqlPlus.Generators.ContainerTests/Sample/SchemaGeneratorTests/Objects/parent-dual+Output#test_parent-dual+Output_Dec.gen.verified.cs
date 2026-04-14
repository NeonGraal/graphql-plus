//HintName: test_parent-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

internal class testRefPrntDualOutpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestRefPrntDualOutpObject>(_ => new testRefPrntDualOutpDecoder());
}

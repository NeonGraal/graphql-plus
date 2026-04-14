//HintName: test_parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

internal class testPrntOutpDecoder
{
}

internal class testRefPrntOutpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntOutpObject>(_ => new testPrntOutpDecoder())
      .AddDecoder<ItestRefPrntOutpObject>(r => new testRefPrntOutpDecoder(r));
}

//HintName: test_parent-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

internal class testPrntDescrOutpDecoder
{
}

internal class testRefPrntDescrOutpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_descr_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_descr_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDescrOutpObject>(_ => new testPrntDescrOutpDecoder())
      .AddDecoder<ItestRefPrntDescrOutpObject>(r => new testRefPrntDescrOutpDecoder(r));
}

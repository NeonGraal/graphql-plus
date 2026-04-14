//HintName: test_parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

internal class testPrntInpDecoder
{
}

internal class testRefPrntInpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntInpObject>(_ => new testPrntInpDecoder())
      .AddDecoder<ItestRefPrntInpObject>(r => new testRefPrntInpDecoder(r));
}

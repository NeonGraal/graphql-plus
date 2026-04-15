//HintName: test_parent-alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

internal class testPrntAltInpDecoder
{
}

internal class testRefPrntAltInpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_alt_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_alt_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntAltInpObject>(_ => new testPrntAltInpDecoder())
      .AddDecoder<ItestRefPrntAltInpObject>(_ => new testRefPrntAltInpDecoder());
}

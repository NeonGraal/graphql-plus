//HintName: test_alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

internal class testAltInpDecoder
{
}

internal class testAltAltInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltInpObject>(_ => new testAltInpDecoder())
      .AddDecoder<ItestAltAltInpObject>(r => new testAltAltInpDecoder(r));
}

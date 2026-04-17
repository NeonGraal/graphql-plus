//HintName: test_alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

internal class testAltInpDecoder
{

  internal static testAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltInpObject>(testAltInpDecoder.Factory)
      .AddDecoder<ItestAltAltInpObject>(testAltAltInpDecoder.Factory);
}

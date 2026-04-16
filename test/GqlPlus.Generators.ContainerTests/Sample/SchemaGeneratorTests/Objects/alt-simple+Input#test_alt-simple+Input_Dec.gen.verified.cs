//HintName: test_alt-simple+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Input;

internal class testAltSmplInpDecoder
{

  internal static testAltSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_simple_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_simple_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltSmplInpObject>(testAltSmplInpDecoder.Factory);
}

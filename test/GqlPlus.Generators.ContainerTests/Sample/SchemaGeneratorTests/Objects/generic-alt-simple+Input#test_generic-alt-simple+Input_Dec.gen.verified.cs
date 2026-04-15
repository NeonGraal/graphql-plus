//HintName: test_generic-alt-simple+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

internal class testGnrcAltSmplInpDecoder
{
}

internal class testRefGnrcAltSmplInpDecoder<TRef>
{
}

internal static class test_generic_alt_simple_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_simple_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltSmplInpObject>(_ => new testGnrcAltSmplInpDecoder());
}

//HintName: test_alt-mod-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

internal class testAltModParamInpDecoder<TMod>
{
}

internal class testAltAltModParamInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_mod_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltAltModParamInpObject>(_ => new testAltAltModParamInpDecoder());
}

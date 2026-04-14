//HintName: test_alt-mod-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

internal class testAltModParamOutpDecoder<TMod>
{
}

internal class testAltAltModParamOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_mod_param_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_param_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltAltModParamOutpObject>(r => new testAltAltModParamOutpDecoder(r));
}

//HintName: test_generic-alt-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

internal class testGnrcAltParamOutpDecoder
{
}

internal class testRefGnrcAltParamOutpDecoder<TRef>
{
}

internal class testAltGnrcAltParamOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_alt_param_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_param_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltParamOutpObject>(_ => new testGnrcAltParamOutpDecoder())
      .AddDecoder<ItestAltGnrcAltParamOutpObject>(r => new testAltGnrcAltParamOutpDecoder(r));
}

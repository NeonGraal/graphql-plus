//HintName: test_generic-alt-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

internal class testGnrcAltParamInpDecoder
{
}

internal class testRefGnrcAltParamInpDecoder<TRef>
{
}

internal class testAltGnrcAltParamInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_alt_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltParamInpObject>(_ => new testGnrcAltParamInpDecoder())
      .AddDecoder<ItestAltGnrcAltParamInpObject>(r => new testAltGnrcAltParamInpDecoder(r));
}

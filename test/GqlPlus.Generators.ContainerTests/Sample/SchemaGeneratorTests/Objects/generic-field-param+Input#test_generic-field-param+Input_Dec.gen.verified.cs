//HintName: test_generic-field-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

internal class testGnrcFieldParamInpDecoder
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
}

internal class testRefGnrcFieldParamInpDecoder<TRef>
{
}

internal class testAltGnrcFieldParamInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_field_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldParamInpObject>(r => new testGnrcFieldParamInpDecoder(r))
      .AddDecoder<ItestAltGnrcFieldParamInpObject>(r => new testAltGnrcFieldParamInpDecoder(r));
}

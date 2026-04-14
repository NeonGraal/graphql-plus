//HintName: test_generic-field-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

internal class testGnrcFieldParamOutpDecoder
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }
}

internal class testRefGnrcFieldParamOutpDecoder<TRef>
{
}

internal class testAltGnrcFieldParamOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_field_param_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_param_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldParamOutpObject>(r => new testGnrcFieldParamOutpDecoder(r))
      .AddDecoder<ItestAltGnrcFieldParamOutpObject>(r => new testAltGnrcFieldParamOutpDecoder(r));
}

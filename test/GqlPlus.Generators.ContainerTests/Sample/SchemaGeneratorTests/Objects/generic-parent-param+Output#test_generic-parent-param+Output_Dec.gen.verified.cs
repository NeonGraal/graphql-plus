//HintName: test_generic-parent-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

internal class testGnrcPrntParamOutpDecoder
{
}

internal class testRefGnrcPrntParamOutpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_parent_param_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_param_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntParamOutpObject>(_ => new testGnrcPrntParamOutpDecoder())
      .AddDecoder<ItestAltGnrcPrntParamOutpObject>(r => new testAltGnrcPrntParamOutpDecoder(r));
}

//HintName: test_generic-parent-param-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

internal class testGnrcPrntParamPrntOutpDecoder
{
}

internal class testRefGnrcPrntParamPrntOutpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamPrntOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_parent_param_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_param_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntParamPrntOutpObject>(_ => new testGnrcPrntParamPrntOutpDecoder())
      .AddDecoder<ItestAltGnrcPrntParamPrntOutpObject>(r => new testAltGnrcPrntParamPrntOutpDecoder(r));
}

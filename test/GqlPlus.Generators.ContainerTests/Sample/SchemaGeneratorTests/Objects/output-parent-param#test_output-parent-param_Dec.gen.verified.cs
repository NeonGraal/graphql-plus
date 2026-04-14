//HintName: test_output-parent-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

internal class testOutpPrntParamDecoder
{
  public ItestFldOutpPrntParam? Field(ItestInOutpPrntParam parameter)
    => null;
  public ItestFldOutpPrntParam? Field()
    => null;
}

internal class testPrntOutpPrntParamDecoder
{
  public ItestFldOutpPrntParam? Field(ItestPrntOutpPrntParamIn parameter)
    => null;
  public ItestFldOutpPrntParam? Field()
    => null;
}

internal class testFldOutpPrntParamDecoder
{
}

internal class testInOutpPrntParamDecoder
{
  public decimal Param { get; set; }
}

internal class testPrntOutpPrntParamInDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_output_parent_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_parent_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestOutpPrntParamObject>(r => new testOutpPrntParamDecoder(r))
      .AddDecoder<ItestPrntOutpPrntParamObject>(r => new testPrntOutpPrntParamDecoder(r))
      .AddDecoder<ItestFldOutpPrntParamObject>(_ => new testFldOutpPrntParamDecoder())
      .AddDecoder<ItestInOutpPrntParamObject>(r => new testInOutpPrntParamDecoder(r))
      .AddDecoder<ItestPrntOutpPrntParamInObject>(r => new testPrntOutpPrntParamInDecoder(r));
}

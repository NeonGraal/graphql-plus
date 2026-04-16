//HintName: test_output-parent-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

internal class testFldOutpPrntParamDecoder
{

  internal static testFldOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpPrntParamDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntParamInDecoder
{
  public decimal Parent { get; set; }

  internal static testPrntOutpPrntParamInDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_parent_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_parent_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpPrntParamObject>(testFldOutpPrntParamDecoder.Factory)
      .AddDecoder<ItestInOutpPrntParamObject>(testInOutpPrntParamDecoder.Factory)
      .AddDecoder<ItestPrntOutpPrntParamInObject>(testPrntOutpPrntParamInDecoder.Factory);
}

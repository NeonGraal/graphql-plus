//HintName: test_output-descr-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

internal class testFldOutpDescrParamDecoder
{
}

internal class testInOutpDescrParamDecoder
{
  public decimal Param { get; set; }
}

internal static class test_output_descr_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_descr_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpDescrParamObject>(_ => new testFldOutpDescrParamDecoder())
      .AddDecoder<ItestInOutpDescrParamObject>(r => new testInOutpDescrParamDecoder(r));
}

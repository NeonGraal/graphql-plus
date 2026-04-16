//HintName: test_output-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

internal class testFldOutpParamDecoder
{

  internal static testFldOutpParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpParamObject>(testFldOutpParamDecoder.Factory)
      .AddDecoder<ItestInOutpParamObject>(testInOutpParamDecoder.Factory);
}

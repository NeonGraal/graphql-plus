//HintName: test_output-param-type-descr_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

internal class testFldOutpParamTypeDescrDecoder
{

  internal static testFldOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamTypeDescrDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_param_type_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_type_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpParamTypeDescrObject>(testFldOutpParamTypeDescrDecoder.Factory)
      .AddDecoder<ItestInOutpParamTypeDescrObject>(testInOutpParamTypeDescrDecoder.Factory);
}

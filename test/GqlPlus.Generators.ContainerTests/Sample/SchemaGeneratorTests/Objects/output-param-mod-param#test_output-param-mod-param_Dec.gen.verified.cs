//HintName: test_output-param-mod-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

internal class testInOutpParamModParamDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamModParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomOutpParamModParamDecoder
{

  internal static testDomOutpParamModParamDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_param_mod_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_mod_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInOutpParamModParamObject>(testInOutpParamModParamDecoder.Factory)
      .AddDecoder<ItestDomOutpParamModParam>(testDomOutpParamModParamDecoder.Factory);
}

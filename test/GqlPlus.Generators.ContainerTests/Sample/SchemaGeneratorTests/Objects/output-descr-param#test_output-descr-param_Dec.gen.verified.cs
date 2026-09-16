//HintName: test_output-descr-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

internal class testFldOutpDescrParamDecoder : NullDecoder<ItestFldOutpDescrParamObject>
{

  internal static testFldOutpDescrParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpDescrParamDecoder : NullDecoder<ItestInOutpDescrParamObject>
{
  public decimal Param { get; set; } = default!;

  internal static testInOutpDescrParamDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_descr_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_descr_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpDescrParamObject>(testFldOutpDescrParamDecoder.Factory)
      .AddDecoder<ItestInOutpDescrParamObject>(testInOutpDescrParamDecoder.Factory);
}

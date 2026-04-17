//HintName: test_output-descr-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

internal class testOutpDescrParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpDescrParamObject>
{
  private readonly IEncoder<ItestFldOutpDescrParam> _itestFldOutpDescrParam = encoders.EncoderFor<ItestFldOutpDescrParam>();
  public Structured Encode(ItestOutpDescrParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpDescrParam);

  internal static testOutpDescrParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpDescrParamEncoder : IEncoder<ItestFldOutpDescrParamObject>
{
  public Structured Encode(ItestFldOutpDescrParamObject input)
    => Structured.Empty();

  internal static testFldOutpDescrParamEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_descr_paramEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_descr_paramEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpDescrParamObject>(testOutpDescrParamEncoder.Factory)
      .AddEncoder<ItestFldOutpDescrParamObject>(testFldOutpDescrParamEncoder.Factory);
}

//HintName: test_output-param-mod-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

internal class testOutpParamModParamEncoder<TMod>(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModParamObject<TMod>>
{
  private readonly IEncoder<ItestDomOutpParamModParam> _itestDomOutpParamModParam = encoders.EncoderFor<ItestDomOutpParamModParam>();
  public Structured Encode(ItestOutpParamModParamObject<TMod> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestDomOutpParamModParam);
}

internal class testInOutpParamModParamEncoder : IEncoder<ItestInOutpParamModParamObject>
{
  public Structured Encode(ItestInOutpParamModParamObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamModParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomOutpParamModParamEncoder : IEncoder<ItestDomOutpParamModParam>
{
  public Structured Encode(ItestDomOutpParamModParam input)
    => input.Value!.Encode();

  internal static testDomOutpParamModParamEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_param_mod_paramEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_param_mod_paramEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInOutpParamModParamObject>(testInOutpParamModParamEncoder.Factory)
      .AddEncoder<ItestDomOutpParamModParam>(testDomOutpParamModParamEncoder.Factory);
}

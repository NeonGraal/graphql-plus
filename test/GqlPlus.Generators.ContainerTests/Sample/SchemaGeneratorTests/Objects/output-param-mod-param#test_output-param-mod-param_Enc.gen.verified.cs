//HintName: test_output-param-mod-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

internal class testOutpParamModParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModParamObject<TMod>>
{
  private readonly IEncoder<ItestDomOutpParamModParam> _itestDomOutpParamModParam = encoders.EncoderFor<ItestDomOutpParamModParam>();
  public Structured Encode(ItestOutpParamModParamObject<TMod> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestDomOutpParamModParam);
}

internal class testInOutpParamModParamEncoder : IEncoder<ItestInOutpParamModParamObject>
{
  public Structured Encode(ItestInOutpParamModParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testDomOutpParamModParamEncoder : IEncoder<ItestDomOutpParamModParam>
{
  public Structured Encode(ItestDomOutpParamModParam input)
    => new(input.Value);
}

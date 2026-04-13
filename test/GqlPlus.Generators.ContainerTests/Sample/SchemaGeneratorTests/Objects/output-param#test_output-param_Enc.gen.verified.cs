//HintName: test_output-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

internal class testOutpParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamObject>
{
  private readonly IEncoder<ItestFldOutpParam> _itestFldOutpParam = encoders.EncoderFor<ItestFldOutpParam>();
  public Structured Encode(ItestOutpParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParam);
}

internal class testFldOutpParamEncoder : IEncoder<ItestFldOutpParamObject>
{
  public Structured Encode(ItestFldOutpParamObject input)
    => Structured.Empty();
}

internal class testInOutpParamEncoder : IEncoder<ItestInOutpParamObject>
{
  public Structured Encode(ItestInOutpParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

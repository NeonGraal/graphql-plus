//HintName: test_output-descr-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
      .AddEncoded("field", input.Field(null), _itestFldOutpDescrParam);
}

internal class testFldOutpDescrParamEncoder : IEncoder<ItestFldOutpDescrParamObject>
{
  public Structured Encode(ItestFldOutpDescrParamObject input)
    => Structured.Empty();
}

internal class testInOutpDescrParamEncoder : IEncoder<ItestInOutpDescrParamObject>
{
  public Structured Encode(ItestInOutpDescrParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

//HintName: test_output-field-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

internal class testOutpFieldParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpFieldParamObject>
{
  private readonly IEncoder<ItestFldOutpFieldParam> _itestFldOutpFieldParam = encoders.EncoderFor<ItestFldOutpFieldParam>();
  public Structured Encode(ItestOutpFieldParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestFldOutpFieldParam);
}

internal class testOutpFieldParam1Encoder : IEncoder<ItestOutpFieldParam1Object>
{
  public Structured Encode(ItestOutpFieldParam1Object input)
    => Structured.Empty();
}

internal class testOutpFieldParam2Encoder : IEncoder<ItestOutpFieldParam2Object>
{
  public Structured Encode(ItestOutpFieldParam2Object input)
    => Structured.Empty();
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public Structured Encode(ItestFldOutpFieldParamObject input)
    => Structured.Empty();
}

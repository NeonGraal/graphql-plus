//HintName: test_output-parent-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

internal class testOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpPrntParamObject>
{
  private readonly IEncoder<ItestPrntOutpPrntParamObject> _itestPrntOutpPrntParam = encoders.EncoderFor<ItestPrntOutpPrntParamObject>();
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestOutpPrntParamObject input)
    => _itestPrntOutpPrntParam.Encode(input)
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);
}

internal class testPrntOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpPrntParamObject>
{
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestPrntOutpPrntParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);
}

internal class testFldOutpPrntParamEncoder : IEncoder<ItestFldOutpPrntParamObject>
{
  public Structured Encode(ItestFldOutpPrntParamObject input)
    => Structured.Empty();
}

internal class testInOutpPrntParamEncoder : IEncoder<ItestInOutpPrntParamObject>
{
  public Structured Encode(ItestInOutpPrntParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testPrntOutpPrntParamInEncoder : IEncoder<ItestPrntOutpPrntParamInObject>
{
  public Structured Encode(ItestPrntOutpPrntParamInObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

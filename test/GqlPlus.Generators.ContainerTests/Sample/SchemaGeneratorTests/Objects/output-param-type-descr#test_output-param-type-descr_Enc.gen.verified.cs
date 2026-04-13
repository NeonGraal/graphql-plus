//HintName: test_output-param-type-descr_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

internal class testOutpParamTypeDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamTypeDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamTypeDescr> _itestFldOutpParamTypeDescr = encoders.EncoderFor<ItestFldOutpParamTypeDescr>();
  public Structured Encode(ItestOutpParamTypeDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestFldOutpParamTypeDescr);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public Structured Encode(ItestFldOutpParamTypeDescrObject input)
    => Structured.Empty();
}

internal class testInOutpParamTypeDescrEncoder : IEncoder<ItestInOutpParamTypeDescrObject>
{
  public Structured Encode(ItestInOutpParamTypeDescrObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

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
      .AddEncoded("field", input.Field(), _itestFldOutpParamTypeDescr);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public Structured Encode(ItestFldOutpParamTypeDescrObject input)
    => Structured.Empty();
}

internal static class test_output_param_type_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_param_type_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpParamTypeDescrObject>(r => new testOutpParamTypeDescrEncoder(r))
      .AddEncoder<ItestFldOutpParamTypeDescrObject>(_ => new testFldOutpParamTypeDescrEncoder());
}

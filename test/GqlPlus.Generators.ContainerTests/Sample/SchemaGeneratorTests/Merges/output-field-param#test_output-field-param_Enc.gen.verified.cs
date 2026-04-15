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
      .AddEncoded("field", input.Field(), _itestFldOutpFieldParam);
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public Structured Encode(ItestFldOutpFieldParamObject input)
    => Structured.Empty();
}

internal static class test_output_field_paramEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_field_paramEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpFieldParamObject>(r => new testOutpFieldParamEncoder(r))
      .AddEncoder<ItestFldOutpFieldParamObject>(_ => new testFldOutpFieldParamEncoder());
}

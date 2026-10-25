//HintName: test_output-field-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

internal class testOutpFieldParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpFieldParamObject>
{
  private readonly Encoder<ItestFldOutpFieldParam> _itestFldOutpFieldParam = encoders.EncoderFor<ItestFldOutpFieldParam>();
  public IGqlpValue Encode(ItestOutpFieldParamObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestFldOutpFieldParam);

  internal static testOutpFieldParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testOutpFieldParam1Encoder : IEncoder<ItestOutpFieldParam1Object>
{
  public IGqlpValue Encode(ItestOutpFieldParam1Object input)
    => new GqlpUnit();

  internal static testOutpFieldParam1Encoder Factory(IEncoderRepository _) => new();
}

internal class testOutpFieldParam2Encoder : IEncoder<ItestOutpFieldParam2Object>
{
  public IGqlpValue Encode(ItestOutpFieldParam2Object input)
    => new GqlpUnit();

  internal static testOutpFieldParam2Encoder Factory(IEncoderRepository _) => new();
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public IGqlpValue Encode(ItestFldOutpFieldParamObject input)
    => new GqlpUnit();

  internal static testFldOutpFieldParamEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_field_paramEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_field_paramEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpFieldParamObject>(testOutpFieldParamEncoder.Factory)
      .AddEncoder<ItestOutpFieldParam1Object>(testOutpFieldParam1Encoder.Factory)
      .AddEncoder<ItestOutpFieldParam2Object>(testOutpFieldParam2Encoder.Factory)
      .AddEncoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamEncoder.Factory);
}

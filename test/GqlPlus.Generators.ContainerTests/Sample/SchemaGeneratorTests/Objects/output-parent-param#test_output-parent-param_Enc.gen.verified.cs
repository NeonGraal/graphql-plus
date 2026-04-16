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

  internal static testOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpPrntParamObject>
{
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestPrntOutpPrntParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);

  internal static testPrntOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpPrntParamEncoder : IEncoder<ItestFldOutpPrntParamObject>
{
  public Structured Encode(ItestFldOutpPrntParamObject input)
    => Structured.Empty();

  internal static testFldOutpPrntParamEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_parent_paramEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_parent_paramEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpPrntParamObject>(testOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestPrntOutpPrntParamObject>(testPrntOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestFldOutpPrntParamObject>(testFldOutpPrntParamEncoder.Factory);
}

//HintName: test_output-param-descr_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

internal class testOutpParamDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamDescr> _itestFldOutpParamDescr = encoders.EncoderFor<ItestFldOutpParamDescr>();
  public Structured Encode(ItestOutpParamDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParamDescr);

  internal static testOutpParamDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamDescrEncoder : IEncoder<ItestFldOutpParamDescrObject>
{
  public Structured Encode(ItestFldOutpParamDescrObject input)
    => Structured.Empty();

  internal static testFldOutpParamDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_param_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_param_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpParamDescrObject>(testOutpParamDescrEncoder.Factory)
      .AddEncoder<ItestFldOutpParamDescrObject>(testFldOutpParamDescrEncoder.Factory);
}

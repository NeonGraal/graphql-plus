//HintName: test_output-param-type-descr_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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

  internal static testOutpParamTypeDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public Structured Encode(ItestFldOutpParamTypeDescrObject input)
    => Structured.Empty();

  internal static testFldOutpParamTypeDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpParamTypeDescrEncoder : IEncoder<ItestInOutpParamTypeDescrObject>
{
  public Structured Encode(ItestInOutpParamTypeDescrObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamTypeDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_param_type_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_param_type_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpParamTypeDescrObject>(testOutpParamTypeDescrEncoder.Factory)
      .AddEncoder<ItestFldOutpParamTypeDescrObject>(testFldOutpParamTypeDescrEncoder.Factory)
      .AddEncoder<ItestInOutpParamTypeDescrObject>(testInOutpParamTypeDescrEncoder.Factory);
}

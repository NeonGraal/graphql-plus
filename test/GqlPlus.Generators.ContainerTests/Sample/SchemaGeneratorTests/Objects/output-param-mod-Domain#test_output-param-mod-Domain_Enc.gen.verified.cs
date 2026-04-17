//HintName: test_output-param-mod-Domain_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

internal class testOutpParamModDmnEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModDmnObject>
{
  private readonly IEncoder<ItestDomOutpParamModDmn> _itestDomOutpParamModDmn = encoders.EncoderFor<ItestDomOutpParamModDmn>();
  public Structured Encode(ItestOutpParamModDmnObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestDomOutpParamModDmn);

  internal static testOutpParamModDmnEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testDomOutpParamModDmnEncoder : IEncoder<ItestDomOutpParamModDmn>
{
  public Structured Encode(ItestDomOutpParamModDmn input)
    => new(input.Value);

  internal static testDomOutpParamModDmnEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_param_mod_DomainEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_param_mod_DomainEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpParamModDmnObject>(testOutpParamModDmnEncoder.Factory)
      .AddEncoder<ItestDomOutpParamModDmn>(testDomOutpParamModDmnEncoder.Factory);
}

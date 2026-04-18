//HintName: test_output-param-mod-Domain_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

internal class testInOutpParamModDmnDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomOutpParamModDmnDecoder
{

  internal static testDomOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_param_mod_DomainDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_mod_DomainDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInOutpParamModDmnObject>(testInOutpParamModDmnDecoder.Factory)
      .AddDecoder<ItestDomOutpParamModDmn>(testDomOutpParamModDmnDecoder.Factory);
}

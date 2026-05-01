//HintName: test_output-param-mod-Domain_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

internal class testInOutpParamModDmnDecoder : IDecoder<ItestInOutpParamModDmnObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamModDmnObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomOutpParamModDmnDecoder : IDecoder<ItestDomOutpParamModDmn>
{

  public IMessages Decode(IValue input, out ItestDomOutpParamModDmn? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_param_mod_DomainDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_mod_DomainDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInOutpParamModDmnObject>(testInOutpParamModDmnDecoder.Factory)
      .AddDecoder<ItestDomOutpParamModDmn>(testDomOutpParamModDmnDecoder.Factory);
}

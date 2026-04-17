//HintName: test_generic-alt-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

internal class testGnrcAltParamInpDecoder
{

  internal static testGnrcAltParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltParamInpDecoder<TRef>
{
}

internal class testAltGnrcAltParamInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_alt_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltParamInpObject>(testGnrcAltParamInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltParamInpObject>(testAltGnrcAltParamInpDecoder.Factory);
}

//HintName: test_generic-parent-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

internal class testGnrcPrntParamInpDecoder
{

  internal static testGnrcPrntParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamInpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_param_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_param_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntParamInpObject>(testGnrcPrntParamInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamInpObject>(testAltGnrcPrntParamInpDecoder.Factory);
}

//HintName: test_generic-parent-param-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

internal class testGnrcPrntParamPrntInpDecoder
{

  internal static testGnrcPrntParamPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamPrntInpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamPrntInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntParamPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_param_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_param_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntParamPrntInpObject>(testGnrcPrntParamPrntInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamPrntInpObject>(testAltGnrcPrntParamPrntInpDecoder.Factory);
}

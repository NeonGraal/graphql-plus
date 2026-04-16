//HintName: test_generic-parent-param-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

internal class testGnrcPrntParamPrntDualDecoder
{

  internal static testGnrcPrntParamPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamPrntDualDecoder<TRef>
{
}

internal class testAltGnrcPrntParamPrntDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntParamPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_param_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_param_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntParamPrntDualObject>(testGnrcPrntParamPrntDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamPrntDualObject>(testAltGnrcPrntParamPrntDualDecoder.Factory);
}

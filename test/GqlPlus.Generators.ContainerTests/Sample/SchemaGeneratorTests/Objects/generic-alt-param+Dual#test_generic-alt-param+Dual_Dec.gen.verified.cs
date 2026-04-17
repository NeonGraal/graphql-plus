//HintName: test_generic-alt-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

internal class testGnrcAltParamDualDecoder
{

  internal static testGnrcAltParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltParamDualDecoder<TRef>
{
}

internal class testAltGnrcAltParamDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_alt_param_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_param_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltParamDualObject>(testGnrcAltParamDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltParamDualObject>(testAltGnrcAltParamDualDecoder.Factory);
}

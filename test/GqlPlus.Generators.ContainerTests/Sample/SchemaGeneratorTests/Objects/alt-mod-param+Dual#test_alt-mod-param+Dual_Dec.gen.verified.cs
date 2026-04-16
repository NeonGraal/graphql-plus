//HintName: test_alt-mod-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

internal class testAltModParamDualDecoder<TMod>
{
}

internal class testAltAltModParamDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltModParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_mod_param_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_param_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltAltModParamDualObject>(testAltAltModParamDualDecoder.Factory);
}

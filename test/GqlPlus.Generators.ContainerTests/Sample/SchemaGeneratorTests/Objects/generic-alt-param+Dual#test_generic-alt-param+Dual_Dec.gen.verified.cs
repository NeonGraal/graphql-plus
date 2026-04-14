//HintName: test_generic-alt-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

internal class testGnrcAltParamDualDecoder
{
}

internal class testRefGnrcAltParamDualDecoder<TRef>
{
}

internal class testAltGnrcAltParamDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_alt_param_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_param_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltParamDualObject>(_ => new testGnrcAltParamDualDecoder())
      .AddDecoder<ItestAltGnrcAltParamDualObject>(_ => new testAltGnrcAltParamDualDecoder());
}

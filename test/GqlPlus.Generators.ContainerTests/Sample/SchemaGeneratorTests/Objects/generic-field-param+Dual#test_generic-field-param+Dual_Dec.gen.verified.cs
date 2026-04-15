//HintName: test_generic-field-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

internal class testGnrcFieldParamDualDecoder
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }
}

internal class testRefGnrcFieldParamDualDecoder<TRef>
{
}

internal class testAltGnrcFieldParamDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_field_param_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_param_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldParamDualObject>(_ => new testGnrcFieldParamDualDecoder())
      .AddDecoder<ItestAltGnrcFieldParamDualObject>(_ => new testAltGnrcFieldParamDualDecoder());
}

//HintName: test_generic-field-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

internal class testGnrcFieldParamDualDecoder
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }

  internal static testGnrcFieldParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldParamDualDecoder<TRef>
{
}

internal class testAltGnrcFieldParamDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_field_param_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_param_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldParamDualObject>(testGnrcFieldParamDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldParamDualObject>(testAltGnrcFieldParamDualDecoder.Factory);
}

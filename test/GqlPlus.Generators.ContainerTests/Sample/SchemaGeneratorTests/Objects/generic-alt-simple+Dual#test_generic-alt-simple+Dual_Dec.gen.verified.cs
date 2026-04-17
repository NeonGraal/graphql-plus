//HintName: test_generic-alt-simple+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

internal class testGnrcAltSmplDualDecoder
{

  internal static testGnrcAltSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltSmplDualDecoder<TRef>
{
}

internal static class test_generic_alt_simple_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_simple_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltSmplDualObject>(testGnrcAltSmplDualDecoder.Factory);
}

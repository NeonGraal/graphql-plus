//HintName: test_alt-simple+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Dual;

internal class testAltSmplDualDecoder
{

  internal static testAltSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_simple_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_simple_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltSmplDualObject>(testAltSmplDualDecoder.Factory);
}

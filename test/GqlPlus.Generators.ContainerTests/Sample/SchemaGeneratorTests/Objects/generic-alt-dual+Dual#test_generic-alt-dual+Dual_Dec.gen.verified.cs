//HintName: test_generic-alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Dual;

internal class testGnrcAltDualDualDecoder
{

  internal static testGnrcAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltDualDualDecoder<TRef>
{
}

internal class testAltGnrcAltDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_alt_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltDualDualObject>(testGnrcAltDualDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltDualDualObject>(testAltGnrcAltDualDualDecoder.Factory);
}

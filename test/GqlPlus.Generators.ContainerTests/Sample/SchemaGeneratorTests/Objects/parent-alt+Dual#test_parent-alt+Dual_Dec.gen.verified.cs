//HintName: test_parent-alt+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

internal class testPrntAltDualDecoder
{

  internal static testPrntAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntAltDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_alt_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_alt_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntAltDualObject>(testPrntAltDualDecoder.Factory)
      .AddDecoder<ItestRefPrntAltDualObject>(testRefPrntAltDualDecoder.Factory);
}

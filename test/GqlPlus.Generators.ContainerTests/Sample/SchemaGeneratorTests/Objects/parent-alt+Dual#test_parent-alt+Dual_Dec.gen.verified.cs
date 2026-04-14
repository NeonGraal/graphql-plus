//HintName: test_parent-alt+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

internal class testPrntAltDualDecoder
{
}

internal class testRefPrntAltDualDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_alt_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_alt_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntAltDualObject>(_ => new testPrntAltDualDecoder())
      .AddDecoder<ItestRefPrntAltDualObject>(r => new testRefPrntAltDualDecoder(r));
}

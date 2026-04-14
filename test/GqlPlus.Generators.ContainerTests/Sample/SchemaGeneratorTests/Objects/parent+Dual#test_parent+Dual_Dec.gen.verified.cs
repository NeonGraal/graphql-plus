//HintName: test_parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

internal class testPrntDualDecoder
{
}

internal class testRefPrntDualDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDualObject>(_ => new testPrntDualDecoder())
      .AddDecoder<ItestRefPrntDualObject>(r => new testRefPrntDualDecoder(r));
}

//HintName: test_parent-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

internal class testPrntDualDualDecoder
{

  internal static testPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDualDualObject>(testPrntDualDualDecoder.Factory)
      .AddDecoder<ItestRefPrntDualDualObject>(testRefPrntDualDualDecoder.Factory);
}

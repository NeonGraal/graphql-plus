//HintName: test_constraint-parent-dual-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

internal class testCnstPrntDualPrntDualDecoder
{

  internal static testCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntDualDecoder
{

  internal static testPrntCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_dual_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualPrntDualObject>(testCnstPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualPrntDualObject>(testPrntCnstPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualPrntDualObject>(testAltCnstPrntDualPrntDualDecoder.Factory);
}

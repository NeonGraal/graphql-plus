//HintName: test_constraint-parent-dual-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

internal class testCnstPrntDualPrntDualDecoder
{
}

internal class testRefCnstPrntDualPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntDualDecoder
{
}

internal class testAltCnstPrntDualPrntDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_parent_dual_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualPrntDualObject>(_ => new testCnstPrntDualPrntDualDecoder())
      .AddDecoder<ItestPrntCnstPrntDualPrntDualObject>(_ => new testPrntCnstPrntDualPrntDualDecoder())
      .AddDecoder<ItestAltCnstPrntDualPrntDualObject>(_ => new testAltCnstPrntDualPrntDualDecoder());
}

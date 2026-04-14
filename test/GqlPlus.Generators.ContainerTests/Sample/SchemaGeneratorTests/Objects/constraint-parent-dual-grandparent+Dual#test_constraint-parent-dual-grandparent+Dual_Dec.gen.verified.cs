//HintName: test_constraint-parent-dual-grandparent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

internal class testCnstPrntDualGrndDualDecoder
{
}

internal class testRefCnstPrntDualGrndDualDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndDualDecoder
{
}

internal class testPrntCnstPrntDualGrndDualDecoder
{
}

internal class testAltCnstPrntDualGrndDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_parent_dual_grandparent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualGrndDualObject>(_ => new testCnstPrntDualGrndDualDecoder())
      .AddDecoder<ItestGrndCnstPrntDualGrndDualObject>(_ => new testGrndCnstPrntDualGrndDualDecoder())
      .AddDecoder<ItestPrntCnstPrntDualGrndDualObject>(_ => new testPrntCnstPrntDualGrndDualDecoder())
      .AddDecoder<ItestAltCnstPrntDualGrndDualObject>(_ => new testAltCnstPrntDualGrndDualDecoder());
}

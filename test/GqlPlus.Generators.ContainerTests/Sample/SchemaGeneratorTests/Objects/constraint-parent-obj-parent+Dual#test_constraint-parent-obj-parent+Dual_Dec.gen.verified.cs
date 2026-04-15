//HintName: test_constraint-parent-obj-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

internal class testCnstPrntObjPrntDualDecoder
{
}

internal class testRefCnstPrntObjPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntDualDecoder
{
}

internal class testAltCnstPrntObjPrntDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_parent_obj_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_obj_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntObjPrntDualObject>(_ => new testCnstPrntObjPrntDualDecoder())
      .AddDecoder<ItestPrntCnstPrntObjPrntDualObject>(_ => new testPrntCnstPrntObjPrntDualDecoder())
      .AddDecoder<ItestAltCnstPrntObjPrntDualObject>(_ => new testAltCnstPrntObjPrntDualDecoder());
}

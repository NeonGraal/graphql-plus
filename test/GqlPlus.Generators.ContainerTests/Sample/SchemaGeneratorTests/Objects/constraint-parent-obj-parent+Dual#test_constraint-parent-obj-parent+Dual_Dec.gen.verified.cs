//HintName: test_constraint-parent-obj-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-obj-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_obj_parent_Dual;

internal class testCnstPrntObjPrntDualDecoder
{

  internal static testCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntObjPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntDualDecoder
{

  internal static testPrntCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_obj_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_obj_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntObjPrntDualObject>(testCnstPrntObjPrntDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntObjPrntDualObject>(testPrntCnstPrntObjPrntDualDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntObjPrntDualObject>(testAltCnstPrntObjPrntDualDecoder.Factory);
}

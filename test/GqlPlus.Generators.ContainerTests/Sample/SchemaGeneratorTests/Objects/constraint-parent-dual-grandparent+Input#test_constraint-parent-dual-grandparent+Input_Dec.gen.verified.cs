//HintName: test_constraint-parent-dual-grandparent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

internal class testCnstPrntDualGrndInpDecoder
{

  internal static testCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualGrndInpDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndInpDecoder
{

  internal static testGrndCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndInpDecoder
{

  internal static testPrntCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualGrndInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_dual_grandparent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualGrndInpObject>(testCnstPrntDualGrndInpDecoder.Factory)
      .AddDecoder<ItestGrndCnstPrntDualGrndInpObject>(testGrndCnstPrntDualGrndInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualGrndInpObject>(testPrntCnstPrntDualGrndInpDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualGrndInpObject>(testAltCnstPrntDualGrndInpDecoder.Factory);
}

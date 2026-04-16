//HintName: test_constraint-parent-dual-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

internal class testCnstPrntDualPrntInpDecoder
{

  internal static testCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntInpDecoder
{

  internal static testPrntCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_parent_dual_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualPrntInpObject>(testCnstPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualPrntInpObject>(testPrntCnstPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualPrntInpObject>(testAltCnstPrntDualPrntInpDecoder.Factory);
}

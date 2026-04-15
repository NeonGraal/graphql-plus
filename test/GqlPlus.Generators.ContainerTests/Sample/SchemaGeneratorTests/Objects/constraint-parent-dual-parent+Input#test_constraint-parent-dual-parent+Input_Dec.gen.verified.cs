//HintName: test_constraint-parent-dual-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Input;

internal class testCnstPrntDualPrntInpDecoder
{
}

internal class testRefCnstPrntDualPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntInpDecoder
{
}

internal class testAltCnstPrntDualPrntInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_parent_dual_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualPrntInpObject>(_ => new testCnstPrntDualPrntInpDecoder())
      .AddDecoder<ItestPrntCnstPrntDualPrntInpObject>(_ => new testPrntCnstPrntDualPrntInpDecoder())
      .AddDecoder<ItestAltCnstPrntDualPrntInpObject>(_ => new testAltCnstPrntDualPrntInpDecoder());
}

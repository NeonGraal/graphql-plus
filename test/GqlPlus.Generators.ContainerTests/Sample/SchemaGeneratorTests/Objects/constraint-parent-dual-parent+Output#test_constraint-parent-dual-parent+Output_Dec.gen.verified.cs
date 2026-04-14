//HintName: test_constraint-parent-dual-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

internal class testCnstPrntDualPrntOutpDecoder
{
}

internal class testRefCnstPrntDualPrntOutpDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntOutpDecoder
{
}

internal class testAltCnstPrntDualPrntOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_parent_dual_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualPrntOutpObject>(_ => new testCnstPrntDualPrntOutpDecoder())
      .AddDecoder<ItestPrntCnstPrntDualPrntOutpObject>(_ => new testPrntCnstPrntDualPrntOutpDecoder())
      .AddDecoder<ItestAltCnstPrntDualPrntOutpObject>(r => new testAltCnstPrntDualPrntOutpDecoder(r));
}

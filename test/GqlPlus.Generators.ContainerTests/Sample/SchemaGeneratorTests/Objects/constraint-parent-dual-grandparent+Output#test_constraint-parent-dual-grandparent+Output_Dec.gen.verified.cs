//HintName: test_constraint-parent-dual-grandparent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

internal class testCnstPrntDualGrndOutpDecoder
{
}

internal class testRefCnstPrntDualGrndOutpDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndOutpDecoder
{
}

internal class testPrntCnstPrntDualGrndOutpDecoder
{
}

internal class testAltCnstPrntDualGrndOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_parent_dual_grandparent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualGrndOutpObject>(_ => new testCnstPrntDualGrndOutpDecoder())
      .AddDecoder<ItestGrndCnstPrntDualGrndOutpObject>(_ => new testGrndCnstPrntDualGrndOutpDecoder())
      .AddDecoder<ItestPrntCnstPrntDualGrndOutpObject>(_ => new testPrntCnstPrntDualGrndOutpDecoder())
      .AddDecoder<ItestAltCnstPrntDualGrndOutpObject>(r => new testAltCnstPrntDualGrndOutpDecoder(r));
}

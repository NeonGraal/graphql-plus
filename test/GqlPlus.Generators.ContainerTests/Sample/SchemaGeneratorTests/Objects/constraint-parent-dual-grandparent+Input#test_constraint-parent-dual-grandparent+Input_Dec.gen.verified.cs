//HintName: test_constraint-parent-dual-grandparent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Input;

internal class testCnstPrntDualGrndInpDecoder
{
}

internal class testRefCnstPrntDualGrndInpDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndInpDecoder
{
}

internal class testPrntCnstPrntDualGrndInpDecoder
{
}

internal class testAltCnstPrntDualGrndInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_parent_dual_grandparent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstPrntDualGrndInpObject>(_ => new testCnstPrntDualGrndInpDecoder())
      .AddDecoder<ItestGrndCnstPrntDualGrndInpObject>(_ => new testGrndCnstPrntDualGrndInpDecoder())
      .AddDecoder<ItestPrntCnstPrntDualGrndInpObject>(_ => new testPrntCnstPrntDualGrndInpDecoder())
      .AddDecoder<ItestAltCnstPrntDualGrndInpObject>(r => new testAltCnstPrntDualGrndInpDecoder(r));
}

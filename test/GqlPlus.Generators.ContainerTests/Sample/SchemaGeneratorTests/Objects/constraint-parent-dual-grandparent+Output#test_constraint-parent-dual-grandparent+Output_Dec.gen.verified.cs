//HintName: test_constraint-parent-dual-grandparent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Output;

internal class testGrndCnstPrntDualGrndOutpDecoder
{
}

internal class testPrntCnstPrntDualGrndOutpDecoder
{
}

internal static class test_constraint_parent_dual_grandparent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGrndCnstPrntDualGrndOutpObject>(_ => new testGrndCnstPrntDualGrndOutpDecoder())
      .AddDecoder<ItestPrntCnstPrntDualGrndOutpObject>(_ => new testPrntCnstPrntDualGrndOutpDecoder());
}

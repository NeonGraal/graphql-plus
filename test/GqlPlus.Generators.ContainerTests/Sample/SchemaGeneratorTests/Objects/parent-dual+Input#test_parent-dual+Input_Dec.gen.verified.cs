//HintName: test_parent-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

internal class testPrntDualInpDecoder
{
}

internal class testRefPrntDualInpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDualInpObject>(_ => new testPrntDualInpDecoder())
      .AddDecoder<ItestRefPrntDualInpObject>(_ => new testRefPrntDualInpDecoder());
}

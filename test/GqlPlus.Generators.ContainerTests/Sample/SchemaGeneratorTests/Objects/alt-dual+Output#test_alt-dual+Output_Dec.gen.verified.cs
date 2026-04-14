//HintName: test_alt-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Output;

internal class testAltDualOutpDecoder
{
}

internal class testObjDualAltDualOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDualOutpObject>(_ => new testAltDualOutpDecoder())
      .AddDecoder<ItestObjDualAltDualOutpObject>(r => new testObjDualAltDualOutpDecoder(r));
}

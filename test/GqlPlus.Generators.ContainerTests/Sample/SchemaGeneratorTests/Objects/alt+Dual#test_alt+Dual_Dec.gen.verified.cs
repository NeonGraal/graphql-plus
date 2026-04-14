//HintName: test_alt+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

internal class testAltDualDecoder
{
}

internal class testAltAltDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDualObject>(_ => new testAltDualDecoder())
      .AddDecoder<ItestAltAltDualObject>(_ => new testAltAltDualDecoder());
}

//HintName: test_alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

internal class testAltDualDualDecoder
{
}

internal class testObjDualAltDualDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDualDualObject>(_ => new testAltDualDualDecoder())
      .AddDecoder<ItestObjDualAltDualDualObject>(r => new testObjDualAltDualDualDecoder(r));
}

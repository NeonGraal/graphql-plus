//HintName: test_alt-simple+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_simple_Dual;

internal class testAltSmplDualEncoder : IEncoder<ItestAltSmplDualObject>
{
  public Structured Encode(ItestAltSmplDualObject input)
    => Structured.Empty();
}

internal static class test_alt_simple_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_simple_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltSmplDualObject>(_ => new testAltSmplDualEncoder());
}

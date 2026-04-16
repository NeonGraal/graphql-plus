//HintName: test_generic-alt-simple+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

internal class testGnrcAltSmplDualEncoder : IEncoder<ItestGnrcAltSmplDualObject>
{
  public Structured Encode(ItestGnrcAltSmplDualObject input)
    => Structured.Empty();

  internal static testGnrcAltSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplDualEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplDualObject<TRef> input)
    => Structured.Empty();
}

internal static class test_generic_alt_simple_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_simple_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltSmplDualObject>(testGnrcAltSmplDualEncoder.Factory);
}

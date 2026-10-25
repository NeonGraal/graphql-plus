//HintName: test_generic-alt-simple+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

internal class testGnrcAltSmplDualEncoder : IEncoder<ItestGnrcAltSmplDualObject>
{
  public IGqlpValue Encode(ItestGnrcAltSmplDualObject input)
    => new GqlpUnit();

  internal static testGnrcAltSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplDualEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltSmplDualObject<TRef> input)
    => new GqlpUnit();
}

internal static class test_generic_alt_simple_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_simple_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltSmplDualObject>(testGnrcAltSmplDualEncoder.Factory);
}

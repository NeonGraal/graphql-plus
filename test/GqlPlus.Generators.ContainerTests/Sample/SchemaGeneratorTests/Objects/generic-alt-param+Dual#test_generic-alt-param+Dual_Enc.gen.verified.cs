//HintName: test_generic-alt-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

internal class testGnrcAltParamDualEncoder : IEncoder<ItestGnrcAltParamDualObject>
{
  public Structured Encode(ItestGnrcAltParamDualObject input)
    => Structured.Empty();

  internal static testGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamDualEncoder<TRef> : IEncoder<ItestRefGnrcAltParamDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamDualEncoder : IEncoder<ItestAltGnrcAltParamDualObject>
{
  public Structured Encode(ItestAltGnrcAltParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_alt_param_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_param_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltParamDualObject>(testGnrcAltParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamDualObject>(testAltGnrcAltParamDualEncoder.Factory);
}

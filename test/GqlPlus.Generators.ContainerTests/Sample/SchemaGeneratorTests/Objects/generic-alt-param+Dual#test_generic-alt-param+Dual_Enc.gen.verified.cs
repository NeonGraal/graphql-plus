//HintName: test_generic-alt-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

internal class testGnrcAltParamDualEncoder : IEncoder<ItestGnrcAltParamDualObject>
{
  public IGqlpValue Encode(ItestGnrcAltParamDualObject input)
    => new GqlpUnit();

  internal static testGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamDualEncoder<TRef> : IEncoder<ItestRefGnrcAltParamDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltParamDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltParamDualEncoder : IEncoder<ItestAltGnrcAltParamDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltParamDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_alt_param_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_param_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltParamDualObject>(testGnrcAltParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamDualObject>(testAltGnrcAltParamDualEncoder.Factory);
}

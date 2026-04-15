//HintName: test_alt-mod-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Dual;

internal class testAltModParamDualEncoder<TMod> : IEncoder<ItestAltModParamDualObject<TMod>>
{
  public Structured Encode(ItestAltModParamDualObject<TMod> input)
    => Structured.Empty();
}

internal class testAltAltModParamDualEncoder : IEncoder<ItestAltAltModParamDualObject>
{
  public Structured Encode(ItestAltAltModParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltAltModParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_mod_param_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_mod_param_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltAltModParamDualObject>(testAltAltModParamDualEncoder.Factory);
}

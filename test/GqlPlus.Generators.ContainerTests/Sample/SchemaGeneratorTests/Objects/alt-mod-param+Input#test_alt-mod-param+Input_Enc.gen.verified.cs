//HintName: test_alt-mod-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Input;

internal class testAltModParamInpEncoder<TMod> : IEncoder<ItestAltModParamInpObject<TMod>>
{
  public IGqlpValue Encode(ItestAltModParamInpObject<TMod> input)
    => new GqlpUnit();
}

internal class testAltAltModParamInpEncoder : IEncoder<ItestAltAltModParamInpObject>
{
  public IGqlpValue Encode(ItestAltAltModParamInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_mod_param_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_mod_param_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltAltModParamInpObject>(testAltAltModParamInpEncoder.Factory);
}

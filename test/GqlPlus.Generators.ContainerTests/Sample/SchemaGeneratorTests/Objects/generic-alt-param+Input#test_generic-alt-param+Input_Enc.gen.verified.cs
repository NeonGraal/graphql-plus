//HintName: test_generic-alt-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

internal class testGnrcAltParamInpEncoder : IEncoder<ItestGnrcAltParamInpObject>
{
  public IGqlpValue Encode(ItestGnrcAltParamInpObject input)
    => new GqlpUnit();

  internal static testGnrcAltParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamInpEncoder<TRef> : IEncoder<ItestRefGnrcAltParamInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltParamInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltParamInpEncoder : IEncoder<ItestAltGnrcAltParamInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltParamInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_alt_param_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_param_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltParamInpObject>(testGnrcAltParamInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamInpObject>(testAltGnrcAltParamInpEncoder.Factory);
}

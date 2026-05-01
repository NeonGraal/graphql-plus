//HintName: test_generic-parent-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

internal class testGnrcPrntParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>> _itestRefGnrcPrntParamInp = encoders.EncoderFor<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>>();
  public Structured Encode(ItestGnrcPrntParamInpObject input)
    => _itestRefGnrcPrntParamInp.Encode(input);

  internal static testGnrcPrntParamInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamInpEncoder : IEncoder<ItestAltGnrcPrntParamInpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_param_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_param_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntParamInpObject>(testGnrcPrntParamInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamInpObject>(testAltGnrcPrntParamInpEncoder.Factory);
}

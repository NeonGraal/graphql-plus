//HintName: test_generic-parent-param-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

internal class testGnrcPrntParamPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntInpObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>> _itestRefGnrcPrntParamPrntInp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>>();
  public IGqlpValue Encode(ItestGnrcPrntParamPrntInpObject input)
    => _itestRefGnrcPrntParamPrntInp.Encode(input);

  internal static testGnrcPrntParamPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamPrntInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamPrntInpEncoder : IEncoder<ItestAltGnrcPrntParamPrntInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamPrntInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_param_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_param_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntParamPrntInpObject>(testGnrcPrntParamPrntInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamPrntInpObject>(testAltGnrcPrntParamPrntInpEncoder.Factory);
}

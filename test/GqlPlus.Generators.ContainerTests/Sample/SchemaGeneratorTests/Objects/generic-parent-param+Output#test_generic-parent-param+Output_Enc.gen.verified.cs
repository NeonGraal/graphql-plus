//HintName: test_generic-parent-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

internal class testGnrcPrntParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>> _itestRefGnrcPrntParamOutp = encoders.EncoderFor<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>>();
  public Structured Encode(ItestGnrcPrntParamOutpObject input)
    => _itestRefGnrcPrntParamOutp.Encode(input);

  internal static testGnrcPrntParamOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamOutpEncoder : IEncoder<ItestAltGnrcPrntParamOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_param_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_param_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntParamOutpObject>(testGnrcPrntParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamOutpObject>(testAltGnrcPrntParamOutpEncoder.Factory);
}

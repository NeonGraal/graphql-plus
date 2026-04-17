//HintName: test_generic-alt-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

internal class testGnrcAltParamOutpEncoder : IEncoder<ItestGnrcAltParamOutpObject>
{
  public Structured Encode(ItestGnrcAltParamOutpObject input)
    => Structured.Empty();

  internal static testGnrcAltParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltParamOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamOutpEncoder : IEncoder<ItestAltGnrcAltParamOutpObject>
{
  public Structured Encode(ItestAltGnrcAltParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

  internal static testAltGnrcAltParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_alt_param_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_param_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltParamOutpObject>(testGnrcAltParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamOutpObject>(testAltGnrcAltParamOutpEncoder.Factory);
}

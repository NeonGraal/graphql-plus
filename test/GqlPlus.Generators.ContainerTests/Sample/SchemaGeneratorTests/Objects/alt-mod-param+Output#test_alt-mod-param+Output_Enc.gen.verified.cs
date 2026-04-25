//HintName: test_alt-mod-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_param_Output;

internal class testAltModParamOutpEncoder<TMod> : IEncoder<ItestAltModParamOutpObject<TMod>>
{
  public Structured Encode(ItestAltModParamOutpObject<TMod> input)
    => Structured.Empty();
}

internal class testAltAltModParamOutpEncoder : IEncoder<ItestAltAltModParamOutpObject>
{
  public Structured Encode(ItestAltAltModParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_mod_param_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_mod_param_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltAltModParamOutpObject>(testAltAltModParamOutpEncoder.Factory);
}

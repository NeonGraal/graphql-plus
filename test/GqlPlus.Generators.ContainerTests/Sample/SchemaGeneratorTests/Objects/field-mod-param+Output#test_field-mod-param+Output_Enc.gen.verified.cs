//HintName: test_field-mod-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

internal class testFieldModParamOutpEncoder<TMod> : IEncoder<ItestFieldModParamOutpObject<TMod>>
{
  public Structured Encode(ItestFieldModParamOutpObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamOutpEncoder : IEncoder<ItestFldFieldModParamOutpObject>
{
  public Structured Encode(ItestFldFieldModParamOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFldFieldModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_mod_param_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_mod_param_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFldFieldModParamOutpObject>(testFldFieldModParamOutpEncoder.Factory);
}

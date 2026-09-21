//HintName: test_field-mod-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

internal class testFieldModParamInpEncoder<TMod> : IEncoder<ItestFieldModParamInpObject<TMod>>
{
  public Structured Encode(ItestFieldModParamInpObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamInpEncoder : IEncoder<ItestFldFieldModParamInpObject>
{
  public Structured Encode(ItestFldFieldModParamInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_mod_param_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_mod_param_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFldFieldModParamInpObject>(testFldFieldModParamInpEncoder.Factory);
}

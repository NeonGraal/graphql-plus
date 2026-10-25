//HintName: test_field-mod-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

internal class testFieldModParamOutpEncoder<TMod> : IEncoder<ItestFieldModParamOutpObject<TMod>>
{
  public IGqlpValue Encode(ItestFieldModParamOutpObject<TMod> input)
    => new GqlpUnit();
}

internal class testFldFieldModParamOutpEncoder : IEncoder<ItestFldFieldModParamOutpObject>
{
  public IGqlpValue Encode(ItestFldFieldModParamOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_mod_param_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_mod_param_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFldFieldModParamOutpObject>(testFldFieldModParamOutpEncoder.Factory);
}

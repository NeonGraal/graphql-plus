//HintName: test_field-mod-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

internal class testFieldModParamDualEncoder<TMod> : IEncoder<ItestFieldModParamDualObject<TMod>>
{
  public Structured Encode(ItestFieldModParamDualObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamDualEncoder : IEncoder<ItestFldFieldModParamDualObject>
{
  public Structured Encode(ItestFldFieldModParamDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_mod_param_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_mod_param_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFldFieldModParamDualObject>(testFldFieldModParamDualEncoder.Factory);
}

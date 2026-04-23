//HintName: test_field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

internal class testFldFieldDualInpEncoder : IEncoder<ItestFldFieldDualInpObject>
{
  public Structured Encode(ItestFldFieldDualInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFldFieldDualInpObject>(testFldFieldDualInpEncoder.Factory);
}

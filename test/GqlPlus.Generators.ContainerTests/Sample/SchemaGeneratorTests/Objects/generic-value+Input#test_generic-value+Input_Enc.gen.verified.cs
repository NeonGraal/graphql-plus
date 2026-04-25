//HintName: test_generic-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

internal class testEnumGnrcValueInpEncoder : IEncoder<testEnumGnrcValueInp>
{
  public Structured Encode(testEnumGnrcValueInp input)
    => input.EncodeEnum("EnumGnrcValueInp");

  internal static testEnumGnrcValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_value_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_value_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumGnrcValueInp>(testEnumGnrcValueInpEncoder.Factory);
}

//HintName: test_field-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

internal class testEnumFieldValueInpEncoder : IEncoder<testEnumFieldValueInp>
{
  public Structured Encode(testEnumFieldValueInp input)
    => new(input.ToString(), "_EnumFieldValueInp");

  internal static testEnumFieldValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_value_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_value_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumFieldValueInp>(testEnumFieldValueInpEncoder.Factory);
}

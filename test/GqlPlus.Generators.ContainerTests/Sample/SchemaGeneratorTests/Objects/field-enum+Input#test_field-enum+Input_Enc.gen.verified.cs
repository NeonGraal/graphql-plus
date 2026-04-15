//HintName: test_field-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

internal class testEnumFieldEnumInpEncoder : IEncoder<testEnumFieldEnumInp>
{
  public Structured Encode(testEnumFieldEnumInp input)
    => new(input.ToString(), "_EnumFieldEnumInp");
}

internal static class test_field_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumFieldEnumInp>(_ => new testEnumFieldEnumInpEncoder());
}

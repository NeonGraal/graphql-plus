//HintName: test_input-field-Enum_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

internal class testEnumInpFieldEnumEncoder : IEncoder<testEnumInpFieldEnum>
{
  public Structured Encode(testEnumInpFieldEnum input)
    => new(input.ToString(), "_EnumInpFieldEnum");
}

internal static class test_input_field_EnumEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_input_field_EnumEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumInpFieldEnum>(_ => new testEnumInpFieldEnumEncoder());
}

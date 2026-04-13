//HintName: test_input-field-Enum_Enc.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

internal class testInpFieldEnumEncoder : IEncoder<ItestInpFieldEnumObject>
{
  public Structured Encode(ItestInpFieldEnumObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumInpFieldEnumEncoder : IEncoder<testEnumInpFieldEnum>
{
  public Structured Encode(testEnumInpFieldEnum input)
    => new(input.ToString(), "_EnumInpFieldEnum");
}

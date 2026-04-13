//HintName: test_object-field-enum-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

internal class testObjFieldEnumAliasInpEncoder : IEncoder<ItestObjFieldEnumAliasInpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

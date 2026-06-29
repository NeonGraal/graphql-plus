//HintName: test_object-field-enum-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Input;

internal class testObjFieldEnumValueInpEncoder : IEncoder<ItestObjFieldEnumValueInpObject>
{
  public Structured Encode(ItestObjFieldEnumValueInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_enum_value_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_enum_value_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldEnumValueInpObject>(testObjFieldEnumValueInpEncoder.Factory);
}

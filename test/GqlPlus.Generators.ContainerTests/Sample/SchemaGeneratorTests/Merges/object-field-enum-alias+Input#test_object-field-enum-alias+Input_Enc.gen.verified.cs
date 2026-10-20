//HintName: test_object-field-enum-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

internal class testObjFieldEnumAliasInpEncoder : IEncoder<ItestObjFieldEnumAliasInpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_enum_alias_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_enum_alias_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldEnumAliasInpObject>(testObjFieldEnumAliasInpEncoder.Factory);
}

//HintName: test_object-field-type-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

internal class testObjFieldTypeAliasInpEncoder : IEncoder<ItestObjFieldTypeAliasInpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_type_alias_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_type_alias_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldTypeAliasInpObject>(testObjFieldTypeAliasInpEncoder.Factory);
}

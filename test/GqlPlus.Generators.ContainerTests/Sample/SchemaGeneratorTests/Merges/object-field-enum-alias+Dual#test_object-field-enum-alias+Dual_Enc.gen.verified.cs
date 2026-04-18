//HintName: test_object-field-enum-alias+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Dual;

internal class testObjFieldEnumAliasDualEncoder : IEncoder<ItestObjFieldEnumAliasDualObject>
{
  public Structured Encode(ItestObjFieldEnumAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldEnumAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_enum_alias_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_enum_alias_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualEncoder.Factory);
}

//HintName: test_object-field-enum-value+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Dual;

internal class testObjFieldEnumValueDualEncoder : IEncoder<ItestObjFieldEnumValueDualObject>
{
  public Structured Encode(ItestObjFieldEnumValueDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_enum_value_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_enum_value_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldEnumValueDualObject>(testObjFieldEnumValueDualEncoder.Factory);
}

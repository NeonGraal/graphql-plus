//HintName: test_object-field-type-alias+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Dual;

internal class testObjFieldTypeAliasDualEncoder : IEncoder<ItestObjFieldTypeAliasDualObject>
{
  public Structured Encode(ItestObjFieldTypeAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldTypeAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_type_alias_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_type_alias_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualEncoder.Factory);
}

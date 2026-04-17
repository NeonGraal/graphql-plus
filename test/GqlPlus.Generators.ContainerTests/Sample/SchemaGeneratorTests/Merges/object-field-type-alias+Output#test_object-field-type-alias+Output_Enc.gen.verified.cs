//HintName: test_object-field-type-alias+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Output;

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldTypeAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_type_alias_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_type_alias_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldTypeAliasOutpObject>(testObjFieldTypeAliasOutpEncoder.Factory);
}

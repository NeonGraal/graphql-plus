//HintName: test_object-field-enum-alias+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Output;

internal class testObjFieldEnumAliasOutpEncoder : IEncoder<ItestObjFieldEnumAliasOutpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testObjFieldEnumAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_enum_alias_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_enum_alias_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldEnumAliasOutpObject>(testObjFieldEnumAliasOutpEncoder.Factory);
}

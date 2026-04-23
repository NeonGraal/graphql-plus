//HintName: test_object-field-enum-value+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Output;

internal class testObjFieldEnumValueOutpEncoder : IEncoder<ItestObjFieldEnumValueOutpObject>
{
  public Structured Encode(ItestObjFieldEnumValueOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_field_enum_value_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_field_enum_value_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjFieldEnumValueOutpObject>(testObjFieldEnumValueOutpEncoder.Factory);
}

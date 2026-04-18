//HintName: test_object-field-enum-value+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Input;

internal class testObjFieldEnumValueInpDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_enum_value_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_enum_value_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldEnumValueInpObject>(testObjFieldEnumValueInpDecoder.Factory);
}

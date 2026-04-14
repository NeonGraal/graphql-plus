//HintName: test_object-field-enum-alias+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Input;

internal class testObjFieldEnumAliasInpDecoder
{
  public bool Field { get; set; }
}

internal static class test_object_field_enum_alias_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_enum_alias_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldEnumAliasInpObject>(_ => new testObjFieldEnumAliasInpDecoder());
}

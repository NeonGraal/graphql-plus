//HintName: test_object-field-type-alias+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Input;

internal class testObjFieldTypeAliasInpDecoder
{
  public string Field { get; set; }
}

internal static class test_object_field_type_alias_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_type_alias_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldTypeAliasInpObject>(r => new testObjFieldTypeAliasInpDecoder(r));
}

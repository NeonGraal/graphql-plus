//HintName: test_object-field-type-alias+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Output;

internal class testObjFieldTypeAliasOutpDecoder
{
  public string Field { get; set; }
}

internal static class test_object_field_type_alias_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_type_alias_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldTypeAliasOutpObject>(r => new testObjFieldTypeAliasOutpDecoder(r));
}

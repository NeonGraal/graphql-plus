//HintName: test_object-field-type-alias+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-type-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_type_alias_Dual;

internal class testObjFieldTypeAliasDualDecoder
{
  public string Field { get; set; }

  internal static testObjFieldTypeAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_type_alias_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_type_alias_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualDecoder.Factory);
}

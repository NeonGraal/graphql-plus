//HintName: test_object-field-enum-alias+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-enum-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_alias_Dual;

internal class testObjFieldEnumAliasDualDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_field_enum_alias_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_enum_alias_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualDecoder.Factory);
}

//HintName: test_object-field-enum-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-field-enum-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_enum_value_Dual;

internal class testObjFieldEnumValueDualDecoder
{
  public bool Field { get; set; }
}

internal static class test_object_field_enum_value_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_field_enum_value_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjFieldEnumValueDualObject>(_ => new testObjFieldEnumValueDualDecoder());
}

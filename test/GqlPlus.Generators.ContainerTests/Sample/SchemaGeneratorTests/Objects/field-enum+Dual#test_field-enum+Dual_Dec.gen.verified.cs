//HintName: test_field-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

internal class testFieldEnumDualDecoder
{
  public testEnumFieldEnumDual Field { get; set; }
}

internal class testEnumFieldEnumDualDecoder
{
  public string fieldEnumDual { get; set; }
}

internal static class test_field_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumDualObject>(r => new testFieldEnumDualDecoder(r))
      .AddDecoder<testEnumFieldEnumDual>(_ => new testEnumFieldEnumDualDecoder());
}

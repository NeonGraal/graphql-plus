//HintName: test_field-mod-Enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Dual;

internal class testFieldModEnumDualDecoder
{
  public IDictionary<testEnumFieldModEnumDual, string> Field { get; set; }
}

internal class testEnumFieldModEnumDualDecoder
{
  public string value { get; set; }
}

internal static class test_field_mod_Enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_Enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldModEnumDualObject>(r => new testFieldModEnumDualDecoder(r))
      .AddDecoder<testEnumFieldModEnumDual>(_ => new testEnumFieldModEnumDualDecoder());
}

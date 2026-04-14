//HintName: test_field-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

internal class testFieldEnumPrntDualDecoder
{
  public testEnumFieldEnumPrntDual Field { get; set; }
}

internal class testEnumFieldEnumPrntDualDecoder
{
  public string prnt_fieldEnumPrntDual { get; set; }
  public string fieldEnumPrntDual { get; set; }
}

internal class testPrntFieldEnumPrntDualDecoder
{
  public string prnt_fieldEnumPrntDual { get; set; }
}

internal static class test_field_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntDualObject>(r => new testFieldEnumPrntDualDecoder(r))
      .AddDecoder<testEnumFieldEnumPrntDual>(_ => new testEnumFieldEnumPrntDualDecoder())
      .AddDecoder<testPrntFieldEnumPrntDual>(_ => new testPrntFieldEnumPrntDualDecoder());
}

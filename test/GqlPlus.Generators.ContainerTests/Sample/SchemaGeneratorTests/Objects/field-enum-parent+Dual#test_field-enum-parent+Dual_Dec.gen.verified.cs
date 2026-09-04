//HintName: test_field-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

internal class testFieldEnumPrntDualDecoder : NullDecoder<ItestFieldEnumPrntDualObject>
{
  public testEnumFieldEnumPrntDual Field { get; set; } = default!;

  internal static testFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualDecoder : NullDecoder<testEnumFieldEnumPrntDual>
{
  public string prnt_fieldEnumPrntDual { get; set; } = default!;
  public string fieldEnumPrntDual { get; set; } = default!;

  internal static testEnumFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualDecoder : NullDecoder<testPrntFieldEnumPrntDual>
{
  public string prnt_fieldEnumPrntDual { get; set; } = default!;

  internal static testPrntFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntDualObject>(testFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntDual>(testEnumFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntDual>(testPrntFieldEnumPrntDualDecoder.Factory);
}

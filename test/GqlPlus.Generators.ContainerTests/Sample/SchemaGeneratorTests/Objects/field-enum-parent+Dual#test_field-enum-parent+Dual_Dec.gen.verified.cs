//HintName: test_field-enum-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

internal class testFieldEnumPrntDualDecoder
{
  public testEnumFieldEnumPrntDual Field { get; set; }

  internal static testFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualDecoder : IDecoder<testEnumFieldEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumPrntDual? output)
    => input.DecodeEnum("EnumFieldEnumPrntDual", out output);

  internal static testEnumFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualDecoder : IDecoder<testPrntFieldEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testPrntFieldEnumPrntDual? output)
    => input.DecodeEnum("PrntFieldEnumPrntDual", out output);

  internal static testPrntFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntDualObject>(testFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntDual?>(testEnumFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntDual?>(testPrntFieldEnumPrntDualDecoder.Factory);
}

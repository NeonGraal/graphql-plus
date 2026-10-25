//HintName: test_field-enum-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

internal class testFieldEnumPrntDualEncoder : IEncoder<ItestFieldEnumPrntDualObject>
{
  public IGqlpValue Encode(ItestFieldEnumPrntDualObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualEncoder : IEncoder<testEnumFieldEnumPrntDual>
{
  public IGqlpValue Encode(testEnumFieldEnumPrntDual input)
    => input.EncodeEnum("EnumFieldEnumPrntDual");

  internal static testEnumFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualEncoder : IEncoder<testPrntFieldEnumPrntDual>
{
  public IGqlpValue Encode(testPrntFieldEnumPrntDual input)
    => input.EncodeEnum("PrntFieldEnumPrntDual");

  internal static testPrntFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_enum_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_enum_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldEnumPrntDualObject>(testFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntDual>(testEnumFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntDual>(testPrntFieldEnumPrntDualEncoder.Factory);
}

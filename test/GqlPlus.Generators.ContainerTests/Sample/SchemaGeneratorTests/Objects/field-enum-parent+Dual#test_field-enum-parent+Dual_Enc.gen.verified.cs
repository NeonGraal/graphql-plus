//HintName: test_field-enum-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Dual;

internal class testFieldEnumPrntDualEncoder : IEncoder<ItestFieldEnumPrntDualObject>
{
  public Structured Encode(ItestFieldEnumPrntDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumPrntDualEncoder : IEncoder<testEnumFieldEnumPrntDual>
{
  public Structured Encode(testEnumFieldEnumPrntDual input)
    => new(input.ToString(), "_EnumFieldEnumPrntDual");
}

internal class testPrntFieldEnumPrntDualEncoder : IEncoder<testPrntFieldEnumPrntDual>
{
  public Structured Encode(testPrntFieldEnumPrntDual input)
    => new(input.ToString(), "_PrntFieldEnumPrntDual");
}

internal static class test_field_enum_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_enum_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldEnumPrntDualObject>(_ => new testFieldEnumPrntDualEncoder())
      .AddEncoder<testEnumFieldEnumPrntDual>(_ => new testEnumFieldEnumPrntDualEncoder())
      .AddEncoder<testPrntFieldEnumPrntDual>(_ => new testPrntFieldEnumPrntDualEncoder());
}

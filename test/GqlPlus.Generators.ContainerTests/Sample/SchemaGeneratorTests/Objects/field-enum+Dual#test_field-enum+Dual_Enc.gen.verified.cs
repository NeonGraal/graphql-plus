//HintName: test_field-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Dual;

internal class testFieldEnumDualEncoder : IEncoder<ItestFieldEnumDualObject>
{
  public Structured Encode(ItestFieldEnumDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumDualEncoder : IEncoder<testEnumFieldEnumDual>
{
  public Structured Encode(testEnumFieldEnumDual input)
    => new(input.ToString(), "_EnumFieldEnumDual");

  internal static testEnumFieldEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldEnumDualObject>(testFieldEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumDual>(testEnumFieldEnumDualEncoder.Factory);
}

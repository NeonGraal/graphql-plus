//HintName: test_field-mod-Enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Dual;

internal class testFieldModEnumDualEncoder : IEncoder<ItestFieldModEnumDualObject>
{
  public Structured Encode(ItestFieldModEnumDualObject input)
    => Structured.Empty();

  internal static testFieldModEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumDualEncoder : IEncoder<testEnumFieldModEnumDual>
{
  public Structured Encode(testEnumFieldModEnumDual input)
    => new(input.ToString(), "_EnumFieldModEnumDual");

  internal static testEnumFieldModEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_mod_Enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_mod_Enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldModEnumDualObject>(testFieldModEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumDual>(testEnumFieldModEnumDualEncoder.Factory);
}

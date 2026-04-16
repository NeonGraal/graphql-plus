//HintName: test_field-value+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

internal class testFieldValueDualEncoder : IEncoder<ItestFieldValueDualObject>
{
  public Structured Encode(ItestFieldValueDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDualEncoder : IEncoder<testEnumFieldValueDual>
{
  public Structured Encode(testEnumFieldValueDual input)
    => new(input.ToString(), "_EnumFieldValueDual");

  internal static testEnumFieldValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_value_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_value_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldValueDualObject>(testFieldValueDualEncoder.Factory)
      .AddEncoder<testEnumFieldValueDual>(testEnumFieldValueDualEncoder.Factory);
}

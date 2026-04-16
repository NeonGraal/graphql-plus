//HintName: test_field-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

internal class testFieldValueDualDecoder
{
  public testEnumFieldValueDual Field { get; set; }

  internal static testFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDualDecoder
{
  public string fieldValueDual { get; set; }

  internal static testEnumFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueDualObject>(testFieldValueDualDecoder.Factory)
      .AddDecoder<testEnumFieldValueDual>(testEnumFieldValueDualDecoder.Factory);
}

//HintName: test_field-value-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Dual;

internal class testFieldValueDescrDualDecoder
{
  public testEnumFieldValueDescrDual Field { get; set; }

  internal static testFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrDualDecoder
{
  public string fieldValueDescrDual { get; set; }

  internal static testEnumFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueDescrDualObject>(testFieldValueDescrDualDecoder.Factory)
      .AddDecoder<testEnumFieldValueDescrDual>(testEnumFieldValueDescrDualDecoder.Factory);
}

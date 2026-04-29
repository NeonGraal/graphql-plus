//HintName: test_field-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

internal class testFieldValueDualDecoder
{
  public testEnumFieldValueDual Field { get; set; }

  internal static testFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDualDecoder : IDecoder<testEnumFieldValueDual?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueDual? output)
    => input.DecodeEnum("EnumFieldValueDual", out output);

  internal static testEnumFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueDualObject>(testFieldValueDualDecoder.Factory)
      .AddDecoder<testEnumFieldValueDual?>(testEnumFieldValueDualDecoder.Factory);
}

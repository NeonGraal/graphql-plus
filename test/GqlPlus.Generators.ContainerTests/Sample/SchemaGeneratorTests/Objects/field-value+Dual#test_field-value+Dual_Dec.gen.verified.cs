//HintName: test_field-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

internal class testFieldValueDualDecoder : IDecoder<ItestFieldValueDualObject>
{
  public testEnumFieldValueDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDualDecoder : IDecoder<testEnumFieldValueDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDual".AnError();
  }

  internal static testEnumFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueDualObject>(testFieldValueDualDecoder.Factory)
      .AddDecoder<testEnumFieldValueDual?>(testEnumFieldValueDualDecoder.Factory);
}

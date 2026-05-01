//HintName: test_field-value-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Dual;

internal class testFieldValueDescrDualDecoder : IDecoder<ItestFieldValueDescrDualObject>
{
  public testEnumFieldValueDescrDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrDualDecoder : IDecoder<testEnumFieldValueDescrDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDescrDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDescrDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDescrDual".AnError();
  }

  internal static testEnumFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueDescrDualObject>(testFieldValueDescrDualDecoder.Factory)
      .AddDecoder<testEnumFieldValueDescrDual?>(testEnumFieldValueDescrDualDecoder.Factory);
}

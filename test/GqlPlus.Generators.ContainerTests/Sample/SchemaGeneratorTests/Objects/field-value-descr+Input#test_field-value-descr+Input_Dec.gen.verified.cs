//HintName: test_field-value-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

internal class testFieldValueDescrInpDecoder : IDecoder<ItestFieldValueDescrInpObject>
{
  public testEnumFieldValueDescrInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrInpDecoder : IDecoder<testEnumFieldValueDescrInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDescrInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDescrInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDescrInp".AnError();
  }

  internal static testEnumFieldValueDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueDescrInpObject>(testFieldValueDescrInpDecoder.Factory)
      .AddDecoder<testEnumFieldValueDescrInp?>(testEnumFieldValueDescrInpDecoder.Factory);
}

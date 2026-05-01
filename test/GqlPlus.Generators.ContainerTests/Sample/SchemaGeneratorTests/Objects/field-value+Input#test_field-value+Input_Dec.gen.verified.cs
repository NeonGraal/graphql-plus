//HintName: test_field-value+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

internal class testFieldValueInpDecoder : IDecoder<ItestFieldValueInpObject>
{
  public testEnumFieldValueInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueInpDecoder : IDecoder<testEnumFieldValueInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueInp".AnError();
  }

  internal static testEnumFieldValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueInpObject>(testFieldValueInpDecoder.Factory)
      .AddDecoder<testEnumFieldValueInp?>(testEnumFieldValueInpDecoder.Factory);
}

//HintName: test_field-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

internal class testEnumFieldValueOutpDecoder : IDecoder<testEnumFieldValueOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueOutp".AnError();
  }

  internal static testEnumFieldValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldValueOutp?>(testEnumFieldValueOutpDecoder.Factory);
}

//HintName: test_field-value-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

internal class testEnumFieldValueDescrOutpDecoder : IDecoder<testEnumFieldValueDescrOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDescrOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDescrOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDescrOutp".AnError();
  }

  internal static testEnumFieldValueDescrOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_descr_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_descr_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldValueDescrOutp?>(testEnumFieldValueDescrOutpDecoder.Factory);
}

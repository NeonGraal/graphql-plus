//HintName: test_field-enum-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Output;

internal class testEnumFieldEnumPrntOutpDecoder : IDecoder<testEnumFieldEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumPrntOutp".AnError();
  }

  internal static testEnumFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpDecoder : IDecoder<testPrntFieldEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testPrntFieldEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntFieldEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntFieldEnumPrntOutp".AnError();
  }

  internal static testPrntFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldEnumPrntOutp?>(testEnumFieldEnumPrntOutpDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntOutp?>(testPrntFieldEnumPrntOutpDecoder.Factory);
}

//HintName: test_field-enum-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

internal class testFieldEnumPrntInpDecoder : IDecoder<ItestFieldEnumPrntInpObject>
{
  public testEnumFieldEnumPrntInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntInpDecoder : IDecoder<testEnumFieldEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumPrntInp".AnError();
  }

  internal static testEnumFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpDecoder : IDecoder<testPrntFieldEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testPrntFieldEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntFieldEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntFieldEnumPrntInp".AnError();
  }

  internal static testPrntFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumPrntInpObject>(testFieldEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntInp?>(testEnumFieldEnumPrntInpDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntInp?>(testPrntFieldEnumPrntInpDecoder.Factory);
}

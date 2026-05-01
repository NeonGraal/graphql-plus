//HintName: test_field-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

internal class testFieldEnumInpDecoder : IDecoder<ItestFieldEnumInpObject>
{
  public testEnumFieldEnumInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumInpDecoder : IDecoder<testEnumFieldEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumInp".AnError();
  }

  internal static testEnumFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumInpObject>(testFieldEnumInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumInp?>(testEnumFieldEnumInpDecoder.Factory);
}

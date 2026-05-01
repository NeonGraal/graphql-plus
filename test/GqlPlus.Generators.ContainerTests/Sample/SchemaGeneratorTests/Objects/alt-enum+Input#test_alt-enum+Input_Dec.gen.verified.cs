//HintName: test_alt-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Input;

internal class testAltEnumInpDecoder : IDecoder<ItestAltEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestAltEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumInpDecoder : IDecoder<testEnumAltEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumAltEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAltEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAltEnumInp".AnError();
  }

  internal static testEnumAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltEnumInpObject>(testAltEnumInpDecoder.Factory)
      .AddDecoder<testEnumAltEnumInp?>(testEnumAltEnumInpDecoder.Factory);
}

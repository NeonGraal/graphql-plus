//HintName: test_alt-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Output;

internal class testEnumAltEnumOutpDecoder : IDecoder<testEnumAltEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumAltEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAltEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAltEnumOutp".AnError();
  }

  internal static testEnumAltEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumAltEnumOutp?>(testEnumAltEnumOutpDecoder.Factory);
}

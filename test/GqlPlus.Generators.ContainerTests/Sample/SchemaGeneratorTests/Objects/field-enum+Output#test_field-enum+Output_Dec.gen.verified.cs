//HintName: test_field-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

internal class testEnumFieldEnumOutpDecoder : IDecoder<testEnumFieldEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumOutp".AnError();
  }

  internal static testEnumFieldEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldEnumOutp?>(testEnumFieldEnumOutpDecoder.Factory);
}

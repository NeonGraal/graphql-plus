//HintName: test_enum-same-parent_Dec.gen.cs
// Generated from {CurrentDirectory}enum-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_same_parent;

internal class testEnumSamePrntDecoder : IDecoder<testEnumSamePrnt?>
{
  public IMessages Decode(IValue input, out testEnumSamePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumSamePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumSamePrnt".AnError();
  }

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder : IDecoder<testPrntEnumSamePrnt?>
{
  public IMessages Decode(IValue input, out testPrntEnumSamePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumSamePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumSamePrnt".AnError();
  }

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_same_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_same_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumSamePrnt?>(testEnumSamePrntDecoder.Factory)
      .AddDecoder<testPrntEnumSamePrnt?>(testPrntEnumSamePrntDecoder.Factory);
}

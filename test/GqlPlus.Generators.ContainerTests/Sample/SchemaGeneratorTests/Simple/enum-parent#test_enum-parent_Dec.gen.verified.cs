//HintName: test_enum-parent_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent;

internal class testEnumPrntDecoder : IDecoder<testEnumPrnt?>
{
  public IMessages Decode(IValue input, out testEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrnt".AnError();
  }

  internal static testEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDecoder : IDecoder<testPrntEnumPrnt?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrnt".AnError();
  }

  internal static testPrntEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrnt?>(testEnumPrntDecoder.Factory)
      .AddDecoder<testPrntEnumPrnt?>(testPrntEnumPrntDecoder.Factory);
}

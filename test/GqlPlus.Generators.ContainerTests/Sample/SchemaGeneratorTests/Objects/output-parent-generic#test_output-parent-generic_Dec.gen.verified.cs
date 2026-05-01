//HintName: test_output-parent-generic_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

internal class testEnumOutpPrntGnrcDecoder : IDecoder<testEnumOutpPrntGnrc?>
{
  public IMessages Decode(IValue input, out testEnumOutpPrntGnrc? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumOutpPrntGnrc value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumOutpPrntGnrc".AnError();
  }

  internal static testEnumOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcDecoder : IDecoder<testPrntOutpPrntGnrc?>
{
  public IMessages Decode(IValue input, out testPrntOutpPrntGnrc? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntOutpPrntGnrc value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntOutpPrntGnrc".AnError();
  }

  internal static testPrntOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_parent_genericDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_parent_genericDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumOutpPrntGnrc?>(testEnumOutpPrntGnrcDecoder.Factory)
      .AddDecoder<testPrntOutpPrntGnrc?>(testPrntOutpPrntGnrcDecoder.Factory);
}

//HintName: test_StarWars_Dec.gen.cs
// Generated from {CurrentDirectory}StarWars.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_StarWars;

internal class testEpisodeDecoder : IDecoder<testEpisode?>
{
  public IMessages Decode(IValue input, out testEpisode? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEpisode value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEpisode".AnError();
  }

  internal static testEpisodeDecoder Factory(IDecoderRepository _) => new();
}

internal class testIdDecoder : IDecoder<ItestId>
{

  public IMessages Decode(IValue input, out ItestId? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testIdDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_StarWarsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_StarWarsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEpisode?>(testEpisodeDecoder.Factory)
      .AddDecoder<ItestId>(testIdDecoder.Factory);
}

//HintName: test_StarWars_Dec.gen.cs
// Generated from {CurrentDirectory}StarWars.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_StarWars;

internal class testEpisodeDecoder : NullDecoder<testEpisode>
{
  public string NewHope { get; set; } = default!;
  public string Empire { get; set; } = default!;
  public string Jedi { get; set; } = default!;

  internal static testEpisodeDecoder Factory(IDecoderRepository _) => new();
}

internal class testIdDecoder : NullDecoder<ItestId>
{

  internal static testIdDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_StarWarsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_StarWarsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEpisode>(testEpisodeDecoder.Factory)
      .AddDecoder<ItestId>(testIdDecoder.Factory);
}

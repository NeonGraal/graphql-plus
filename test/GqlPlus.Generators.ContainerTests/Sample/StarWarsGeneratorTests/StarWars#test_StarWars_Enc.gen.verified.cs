//HintName: test_StarWars_Enc.gen.cs
// Generated from {CurrentDirectory}StarWars.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_StarWars;

internal class testQueryEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestQueryObject>
{
  private readonly Encoder<ItestCharacter> _itestCharacter = encoders.EncoderFor<ItestCharacter>();
  private readonly Encoder<ItestHuman> _itestHuman = encoders.EncoderFor<ItestHuman>();
  private readonly Encoder<ItestDroid> _itestDroid = encoders.EncoderFor<ItestDroid>();
  public Structured Encode(ItestQueryObject input)
    => Structured.Empty()
      .AddEncoded("hero", input.Hero(), _itestCharacter)
      .AddEncoded("human", input.Human(), _itestHuman)
      .AddEncoded("droid", input.Droid(), _itestDroid)
      .AddList("characters", input.Characters(), _itestCharacter);

  internal static testQueryEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testEpisodeEncoder : IEncoder<testEpisode>
{
  public Structured Encode(testEpisode input)
    => input.EncodeEnum("Episode");

  internal static testEpisodeEncoder Factory(IEncoderRepository _) => new();
}

internal class testIdEncoder : IEncoder<ItestId>
{
  public Structured Encode(ItestId input)
    => input.Value!.Encode();

  internal static testIdEncoder Factory(IEncoderRepository _) => new();
}

internal class testCharacterEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCharacterObject>
{
  private readonly Encoder<ItestId> _itestId = encoders.EncoderFor<ItestId>();
  public Structured Encode(ItestCharacterObject input)
    => Structured.Empty()
      .AddEncoded("id", input.Id, _itestId)
      .Add("name", input.Name.Encode())
      .AddList("friends", input.Friends, _itestId)
      .Add("appearsIn", input.AppearsIn.Encode());

  internal static testCharacterEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testHumanEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestHumanObject>
{
  private readonly Encoder<ItestCharacterObject> _itestCharacter = encoders.EncoderFor<ItestCharacterObject>();
  public Structured Encode(ItestHumanObject input)
    => _itestCharacter.Encode(input)
      .Add("homePlanet", input.HomePlanet.Encode());

  internal static testHumanEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testDroidEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestDroidObject>
{
  private readonly Encoder<ItestCharacterObject> _itestCharacter = encoders.EncoderFor<ItestCharacterObject>();
  public Structured Encode(ItestDroidObject input)
    => _itestCharacter.Encode(input)
      .Add("primaryFunction", input.PrimaryFunction.Encode());

  internal static testDroidEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_StarWarsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_StarWarsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestQueryObject>(testQueryEncoder.Factory)
      .AddEncoder<testEpisode>(testEpisodeEncoder.Factory)
      .AddEncoder<ItestId>(testIdEncoder.Factory)
      .AddEncoder<ItestCharacterObject>(testCharacterEncoder.Factory)
      .AddEncoder<ItestHumanObject>(testHumanEncoder.Factory)
      .AddEncoder<ItestDroidObject>(testDroidEncoder.Factory);
}

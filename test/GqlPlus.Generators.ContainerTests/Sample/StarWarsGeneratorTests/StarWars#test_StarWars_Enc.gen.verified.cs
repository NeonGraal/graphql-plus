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
      .AddEncoded("hero", input.Hero, _itestCharacter)
      .AddEncoded("human", input.Human, _itestHuman)
      .AddEncoded("droid", input.Droid, _itestDroid)
      .AddList("characters", input.Characters, _itestCharacter);

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

internal class testRoleEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRoleObject>
{
  private readonly Encoder<ItestId> _itestId = encoders.EncoderFor<ItestId>();
  public Structured Encode(ItestRoleObject input)
    => Structured.Empty()
      .AddEncoded("id", input.Id, _itestId)
      .Add("name", input.Name.Encode())
      .Add("appearsIn", input.AppearsIn.Encode());

  internal static testRoleEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAssociateEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAssociateObject>
{
  private readonly Encoder<ItestRoleObject> _itestRole = encoders.EncoderFor<ItestRoleObject>();
  private readonly Encoder<ItestRole> _itestRole2 = encoders.EncoderFor<ItestRole>();
  public Structured Encode(ItestAssociateObject input)
    => _itestRole.Encode(input)
      .AddList("friends", input.Friends, _itestRole2);

  internal static testAssociateEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testHumanEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestHumanObject>
{
  private readonly Encoder<ItestAssociateObject> _itestAssociate = encoders.EncoderFor<ItestAssociateObject>();
  public Structured Encode(ItestHumanObject input)
    => _itestAssociate.Encode(input)
      .AddIf(input.HomePlanet is not null, onTrue: t => t.Add("homePlanet", input.HomePlanet!.Encode()));

  internal static testHumanEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testDroidEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestDroidObject>
{
  private readonly Encoder<ItestAssociateObject> _itestAssociate = encoders.EncoderFor<ItestAssociateObject>();
  public Structured Encode(ItestDroidObject input)
    => _itestAssociate.Encode(input)
      .Add("primaryFunction", input.PrimaryFunction.Encode());

  internal static testDroidEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCharacterEncoder : IEncoder<ItestCharacterObject>
{
  public Structured Encode(ItestCharacterObject input)
    => Structured.Empty();

  internal static testCharacterEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_StarWarsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_StarWarsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestQueryObject>(testQueryEncoder.Factory)
      .AddEncoder<testEpisode>(testEpisodeEncoder.Factory)
      .AddEncoder<ItestId>(testIdEncoder.Factory)
      .AddEncoder<ItestRoleObject>(testRoleEncoder.Factory)
      .AddEncoder<ItestAssociateObject>(testAssociateEncoder.Factory)
      .AddEncoder<ItestHumanObject>(testHumanEncoder.Factory)
      .AddEncoder<ItestDroidObject>(testDroidEncoder.Factory)
      .AddEncoder<ItestCharacterObject>(testCharacterEncoder.Factory);
}

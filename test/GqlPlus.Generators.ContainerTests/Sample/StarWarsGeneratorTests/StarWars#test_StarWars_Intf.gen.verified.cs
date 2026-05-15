//HintName: test_StarWars_Intf.gen.cs
// Generated from {CurrentDirectory}StarWars.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_StarWars;

public interface ItestQuery
  : IGqlpInterfaceBase
{
  ItestQueryObject? As_Query { get; }
}

public interface ItestQueryObject
  : IGqlpInterfaceBase
{
  ItestCharacter? Hero(testEpisode? parameter);
  ItestCharacter? Hero();
  ItestHuman? Human(string parameter);
  ItestHuman? Human();
  ItestDroid? Droid(ItestId parameter);
  ItestDroid? Droid();
  ICollection<ItestCharacter>? Characters(ICollection<ItestId> parameter);
  ICollection<ItestCharacter>? Characters();
}

public enum testEpisode
{
  NewHope,
  Empire,
  Jedi,
}

public interface ItestId
  : IGqlpDomainNumber
{
}

public interface ItestCharacter
  : IGqlpInterfaceBase
{
  ItestCharacterObject? As_Character { get; }
}

public interface ItestCharacterObject
  : IGqlpInterfaceBase
{
  ItestId Id { get; }
  string Name { get; }
  ICollection<ItestId>? Friends { get; }
  ICollection<testEpisode> AppearsIn { get; }
}

public interface ItestHuman
  : ItestCharacter
{
  ItestHumanObject? As_Human { get; }
}

public interface ItestHumanObject
  : ItestCharacterObject
{
  string HomePlanet { get; }
}

public interface ItestDroid
  : ItestCharacter
{
  ItestDroidObject? As_Droid { get; }
}

public interface ItestDroidObject
  : ItestCharacterObject
{
  string PrimaryFunction { get; }
}

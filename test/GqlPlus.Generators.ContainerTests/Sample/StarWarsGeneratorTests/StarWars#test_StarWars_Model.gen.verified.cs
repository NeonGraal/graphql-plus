//HintName: test_StarWars_Model.gen.cs
// Generated from {CurrentDirectory}StarWars.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_StarWars;

public class testQuery
  : GqlpModelBase
  , ItestQuery
{
  public ItestQueryObject? As_Query { get; set; }
}

public class testQueryObject
  : GqlpModelBase
  , ItestQueryObject
{
  public ItestCharacter? Hero(testEpisode? parameter)
    => null;
  public ItestCharacter? Hero()
    => null;
  public ItestHuman? Human(string parameter)
    => null;
  public ItestHuman? Human()
    => null;
  public ItestDroid? Droid(ItestId parameter)
    => null;
  public ItestDroid? Droid()
    => null;
  public ICollection<ItestCharacter>? Characters(ICollection<ItestId> parameter)
    => null;
  public ICollection<ItestCharacter>? Characters()
    => null;

  public testQueryObject
    ()
  {
  }
}

public class testId
  : GqlpDomainNumber
  , ItestId
{
}

public class testCharacter
  : GqlpModelBase
  , ItestCharacter
{
  public ItestCharacterObject? As_Character { get; set; }
}

public class testCharacterObject
  : GqlpModelBase
  , ItestCharacterObject
{
  public ItestId Id { get; set; }
  public string Name { get; set; }
  public ICollection<ItestId>? Friends { get; set; }
  public ICollection<testEpisode> AppearsIn { get; set; }

  public testCharacterObject
    ( ItestId pid
    , string pname
    , ICollection<testEpisode> pappearsIn
    )
  {
    Id = pid;
    Name = pname;
    AppearsIn = pappearsIn;
  }
}

public class testHuman
  : testCharacter
  , ItestHuman
{
  public ItestHumanObject? As_Human { get; set; }
}

public class testHumanObject
  : testCharacterObject
  , ItestHumanObject
{
  public string HomePlanet { get; set; }

  public testHumanObject
    ( ItestId pid
    , string pname
    , ICollection<testEpisode> pappearsIn
    , string phomePlanet
    ) : base(pid, pname, pappearsIn)
  {
    HomePlanet = phomePlanet;
  }
}

public class testDroid
  : testCharacter
  , ItestDroid
{
  public ItestDroidObject? As_Droid { get; set; }
}

public class testDroidObject
  : testCharacterObject
  , ItestDroidObject
{
  public string PrimaryFunction { get; set; }

  public testDroidObject
    ( ItestId pid
    , string pname
    , ICollection<testEpisode> pappearsIn
    , string pprimaryFunction
    ) : base(pid, pname, pappearsIn)
  {
    PrimaryFunction = pprimaryFunction;
  }
}

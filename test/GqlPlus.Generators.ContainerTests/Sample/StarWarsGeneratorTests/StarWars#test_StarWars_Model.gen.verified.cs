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
  public ICollection<ItestCharacter>? Characters(ICollection<ItestId>? parameter)
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

public class testRole
  : GqlpModelBase
  , ItestRole
{
  public ItestRoleObject? As_Role { get; set; }
}

public class testRoleObject
  : GqlpModelBase
  , ItestRoleObject
{
  public ItestId Id { get; set; }
  public string Name { get; set; }
  public ICollection<testEpisode> AppearsIn { get; set; }

  public testRoleObject
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

public class testAssociate
  : testRole
  , ItestAssociate
{
  public ItestAssociateObject? As_Associate { get; set; }
}

public class testAssociateObject
  : testRoleObject
  , ItestAssociateObject
{
  public ICollection<ItestRole> Friends { get; set; }

  public testAssociateObject
    ( ItestId pid
    , string pname
    , ICollection<testEpisode> pappearsIn
    , ICollection<ItestRole> pfriends
    ) : base(pid, pname, pappearsIn)
  {
    Friends = pfriends;
  }
}

public class testHuman
  : testAssociate
  , ItestHuman
{
  public ItestHumanObject? As_Human { get; set; }
}

public class testHumanObject
  : testAssociateObject
  , ItestHumanObject
{
  public string HomePlanet { get; set; }

  public testHumanObject
    ( ItestId pid
    , string pname
    , ICollection<testEpisode> pappearsIn
    , ICollection<ItestRole> pfriends
    , string phomePlanet
    ) : base(pid, pname, pappearsIn, pfriends)
  {
    HomePlanet = phomePlanet;
  }
}

public class testDroid
  : testAssociate
  , ItestDroid
{
  public ItestDroidObject? As_Droid { get; set; }
}

public class testDroidObject
  : testAssociateObject
  , ItestDroidObject
{
  public string PrimaryFunction { get; set; }

  public testDroidObject
    ( ItestId pid
    , string pname
    , ICollection<testEpisode> pappearsIn
    , ICollection<ItestRole> pfriends
    , string pprimaryFunction
    ) : base(pid, pname, pappearsIn, pfriends)
  {
    PrimaryFunction = pprimaryFunction;
  }
}

public class testCharacter
  : GqlpModelBase
  , ItestCharacter
{
  public ItestHuman? AsHuman { get; set; }
  public ItestDroid? AsDroid { get; set; }
  public ItestCharacterObject? As_Character { get; set; }
}

public class testCharacterObject
  : GqlpModelBase
  , ItestCharacterObject
{

  public testCharacterObject
    ()
  {
  }
}

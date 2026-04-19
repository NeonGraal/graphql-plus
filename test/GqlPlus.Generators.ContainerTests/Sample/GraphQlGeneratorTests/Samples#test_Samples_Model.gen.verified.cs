//HintName: test_Samples_Model.gen.cs
// Generated from {CurrentDirectory}Samples.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Samples;

public class testQuery
  : GqlpModelBase
  , ItestQuery
{
  public ItestFullUser? AsFullUser { get; set; }
  public ItestQueryObject? As_Query { get; set; }
}

public class testQueryObject
  : GqlpModelBase
  , ItestQueryObject
{
  public ItestFullUser? User(ItestUserFilter parameter)
    => null;
  public ItestFullUser? User()
    => null;
  public ItestStory? LikeStory(ItestStoryFilter parameter)
    => null;
  public ItestStory? LikeStory()
    => null;
  public string? Field(ItestFieldFilter parameter)
    => null;
  public string? Field()
    => null;
  public ItestFullUser Me { get; set; }
  public string? Picture(ItestPicFilter parameter)
    => null;
  public string? Picture()
    => null;
  public ICollection<ItestProfile>? Profiles(ItestProfileFilter parameter)
    => null;
  public ICollection<ItestProfile>? Profiles()
    => null;
  public string? NearestThing(ItestThingFilter parameter)
    => null;
  public string? NearestThing()
    => null;

  public testQueryObject
    ( ItestFullUser me
    )
  {
    Me = me;
  }
}

public class testMutation
  : GqlpModelBase
  , ItestMutation
{
  public ItestMutationObject? As_Mutation { get; set; }
}

public class testMutationObject
  : GqlpModelBase
  , ItestMutationObject
{
  public bool? SendEmail(ItestEmail parameter)
    => null;
  public bool? SendEmail()
    => null;

  public testMutationObject
    ()
  {
  }
}

public class testUserFilter
  : GqlpModelBase
  , ItestUserFilter
{
  public ItestUserFilterObject? As_UserFilter { get; set; }
}

public class testUserFilterObject
  : GqlpModelBase
  , ItestUserFilterObject
{
  public decimal Id { get; set; }

  public testUserFilterObject
    ( decimal id
    )
  {
    Id = id;
  }
}

public class testUser
  : GqlpModelBase
  , ItestUser
{
  public ItestUserObject? As_User { get; set; }
}

public class testUserObject
  : GqlpModelBase
  , ItestUserObject
{
  public decimal Id { get; set; }
  public string Name { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public ItestDate Birthday { get; set; }

  public testUserObject
    ( decimal id
    , string name
    , string firstName
    , string lastName
    , ItestDate birthday
    )
  {
    Id = id;
    Name = name;
    FirstName = firstName;
    LastName = lastName;
    Birthday = birthday;
  }
}

public class testFullUser
  : testUser
  , ItestFullUser
{
  public ItestFullUserObject? As_FullUser { get; set; }
}

public class testFullUserObject
  : testUserObject
  , ItestFullUserObject
{
  public string? ProfilePic(ItestPicFilter parameter)
    => null;
  public string? ProfilePic()
    => null;
  public ItestUserList? Friends(ItestFriendsFilter parameter)
    => null;
  public ItestUserList? Friends()
    => null;
  public ItestUserList? MutualFriends(ItestFriendsFilter parameter)
    => null;
  public ItestUserList? MutualFriends()
    => null;

  public testFullUserObject
    ( decimal id
    , string name
    , string firstName
    , string lastName
    , ItestDate birthday
    ) : base(id, name, firstName, lastName, birthday)
  {
  }
}

public class testUserList
  : GqlpModelBase
  , ItestUserList
{
  public ICollection<ItestUser>? AsUser { get; set; }
  public ItestUserListObject? As_UserList { get; set; }
}

public class testUserListObject
  : GqlpModelBase
  , ItestUserListObject
{
  public decimal Count { get; set; }
  public ICollection<ItestUser> Users { get; set; }

  public testUserListObject
    ( decimal count
    , ICollection<ItestUser> users
    )
  {
    Count = count;
    Users = users;
  }
}

public class testStoryFilter
  : GqlpModelBase
  , ItestStoryFilter
{
  public ItestStoryFilterObject? As_StoryFilter { get; set; }
}

public class testStoryFilterObject
  : GqlpModelBase
  , ItestStoryFilterObject
{
  public decimal StoryID { get; set; }

  public testStoryFilterObject
    ( decimal storyID
    )
  {
    StoryID = storyID;
  }
}

public class testStory
  : GqlpModelBase
  , ItestStory
{
  public ItestStoryObject? As_Story { get; set; }
}

public class testStoryObject
  : GqlpModelBase
  , ItestStoryObject
{
  public decimal LikeCount { get; set; }

  public testStoryObject
    ( decimal likeCount
    )
  {
    LikeCount = likeCount;
  }
}

public class testFieldFilter
  : GqlpModelBase
  , ItestFieldFilter
{
  public ItestFieldFilterObject? As_FieldFilter { get; set; }
}

public class testFieldFilterObject
  : GqlpModelBase
  , ItestFieldFilterObject
{
  public string? Arg { get; set; }

  public testFieldFilterObject
    ()
  {
  }
}

public class testPicFilter
  : GqlpModelBase
  , ItestPicFilter
{
  public ItestPicFilterObject? As_PicFilter { get; set; }
}

public class testPicFilterObject
  : GqlpModelBase
  , ItestPicFilterObject
{
  public decimal Size { get; set; }
  public decimal Width { get; set; }
  public decimal Height { get; set; }

  public testPicFilterObject
    ( decimal size
    , decimal width
    , decimal height
    )
  {
    Size = size;
    Width = width;
    Height = height;
  }
}

public class testFriendsFilter
  : GqlpModelBase
  , ItestFriendsFilter
{
  public ItestFriendsFilterObject? As_FriendsFilter { get; set; }
}

public class testFriendsFilterObject
  : GqlpModelBase
  , ItestFriendsFilterObject
{
  public decimal First { get; set; }

  public testFriendsFilterObject
    ( decimal first
    )
  {
    First = first;
  }
}

public class testProfile
  : testUser
  , ItestProfile
{
  public ItestPage? AsPage { get; set; }
  public ItestProfileObject? As_Profile { get; set; }
}

public class testProfileObject
  : testUserObject
  , ItestProfileObject
{
  public string Handle { get; set; }

  public testProfileObject
    ( decimal id
    , string name
    , string firstName
    , string lastName
    , ItestDate birthday
    , string handle
    ) : base(id, name, firstName, lastName, birthday)
  {
    Handle = handle;
  }
}

public class testProfileFilter
  : GqlpModelBase
  , ItestProfileFilter
{
  public ItestProfileFilterObject? As_ProfileFilter { get; set; }
}

public class testProfileFilterObject
  : GqlpModelBase
  , ItestProfileFilterObject
{
  public ICollection<string> Handles { get; set; }

  public testProfileFilterObject
    ( ICollection<string> handles
    )
  {
    Handles = handles;
  }
}

public class testPage
  : GqlpModelBase
  , ItestPage
{
  public ItestPageObject? As_Page { get; set; }
}

public class testPageObject
  : GqlpModelBase
  , ItestPageObject
{
  public string Handle { get; set; }
  public ItestUserList Likers { get; set; }

  public testPageObject
    ( string handle
    , ItestUserList likers
    )
  {
    Handle = handle;
    Likers = likers;
  }
}

public class testIncludeParams
  : GqlpModelBase
  , ItestIncludeParams
{
  public ItestIncludeParamsObject? As_IncludeParams { get; set; }
}

public class testIncludeParamsObject
  : GqlpModelBase
  , ItestIncludeParamsObject
{
  public bool If { get; set; }

  public testIncludeParamsObject
    ( bool if
    )
  {
    If = if;
  }
}

public class testEmail
  : GqlpModelBase
  , ItestEmail
{
  public ItestEmailObject? As_Email { get; set; }
}

public class testEmailObject
  : GqlpModelBase
  , ItestEmailObject
{
  public string Message { get; set; }

  public testEmailObject
    ( string message
    )
  {
    Message = message;
  }
}

public class testThingFilter
  : GqlpModelBase
  , ItestThingFilter
{
  public ItestThingFilterObject? As_ThingFilter { get; set; }
}

public class testThingFilterObject
  : GqlpModelBase
  , ItestThingFilterObject
{
  public ItestLocation Location { get; set; }

  public testThingFilterObject
    ( ItestLocation location
    )
  {
    Location = location;
  }
}

public class testLocation
  : GqlpModelBase
  , ItestLocation
{
  public ItestLocationObject? As_Location { get; set; }
}

public class testLocationObject
  : GqlpModelBase
  , ItestLocationObject
{
  public decimal Lat { get; set; }
  public decimal Lon { get; set; }

  public testLocationObject
    ( decimal lat
    , decimal lon
    )
  {
    Lat = lat;
    Lon = lon;
  }
}

public class testInt
  : GqlpDomainNumber
  , ItestInt
{
}

public class testDate
  : GqlpDomainString
  , ItestDate
{
}

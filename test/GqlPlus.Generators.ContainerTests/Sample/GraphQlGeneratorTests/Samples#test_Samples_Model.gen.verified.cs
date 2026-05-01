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
  public ItestFullUser User { get; set; }
  public ItestFullUser? Call_User(ItestUserFilter parameter)
    => null;
  public ItestStory LikeStory { get; set; }
  public ItestStory? Call_LikeStory(ItestStoryFilter parameter)
    => null;
  public string Field { get; set; }
  public string? Call_Field(ItestFieldFilter parameter)
    => null;
  public ItestFullUser Me { get; set; }
  public string Picture { get; set; }
  public string? Call_Picture(ItestPicFilter parameter)
    => null;
  public ICollection<ItestProfile> Profiles { get; set; }
  public ICollection<ItestProfile>? Call_Profiles(ItestProfileFilter parameter)
    => null;
  public string NearestThing { get; set; }
  public string? Call_NearestThing(ItestThingFilter parameter)
    => null;

  public testQueryObject
    ( ItestFullUser puser
    , ItestStory plikeStory
    , string pfield
    , ItestFullUser pme
    , string ppicture
    , ICollection<ItestProfile> pprofiles
    , string pnearestThing
    )
  {
    User = puser;
    LikeStory = plikeStory;
    Field = pfield;
    Me = pme;
    Picture = ppicture;
    Profiles = pprofiles;
    NearestThing = pnearestThing;
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
  public bool SendEmail { get; set; }
  public bool? Call_SendEmail(ItestEmail parameter)
    => null;

  public testMutationObject
    ( bool psendEmail
    )
  {
    SendEmail = psendEmail;
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
    ( decimal pid
    )
  {
    Id = pid;
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
    ( decimal pid
    , string pname
    , string pfirstName
    , string plastName
    , ItestDate pbirthday
    )
  {
    Id = pid;
    Name = pname;
    FirstName = pfirstName;
    LastName = plastName;
    Birthday = pbirthday;
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
  public string ProfilePic { get; set; }
  public string? Call_ProfilePic(ItestPicFilter parameter)
    => null;
  public ItestUserList Friends { get; set; }
  public ItestUserList? Call_Friends(ItestFriendsFilter parameter)
    => null;
  public ItestUserList MutualFriends { get; set; }
  public ItestUserList? Call_MutualFriends(ItestFriendsFilter parameter)
    => null;

  public testFullUserObject
    ( decimal pid
    , string pname
    , string pfirstName
    , string plastName
    , ItestDate pbirthday
    , string pprofilePic
    , ItestUserList pfriends
    , ItestUserList pmutualFriends
    ) : base(pid, pname, pfirstName, plastName, pbirthday)
  {
    ProfilePic = pprofilePic;
    Friends = pfriends;
    MutualFriends = pmutualFriends;
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
    ( decimal pcount
    , ICollection<ItestUser> pusers
    )
  {
    Count = pcount;
    Users = pusers;
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
    ( decimal pstoryID
    )
  {
    StoryID = pstoryID;
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
    ( decimal plikeCount
    )
  {
    LikeCount = plikeCount;
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
    ( decimal psize
    , decimal pwidth
    , decimal pheight
    )
  {
    Size = psize;
    Width = pwidth;
    Height = pheight;
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
    ( decimal pfirst
    )
  {
    First = pfirst;
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
    ( decimal pid
    , string pname
    , string pfirstName
    , string plastName
    , ItestDate pbirthday
    , string phandle
    ) : base(pid, pname, pfirstName, plastName, pbirthday)
  {
    Handle = phandle;
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
    ( ICollection<string> phandles
    )
  {
    Handles = phandles;
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
    ( string phandle
    , ItestUserList plikers
    )
  {
    Handle = phandle;
    Likers = plikers;
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
    ( bool pif
    )
  {
    If = pif;
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
    ( string pmessage
    )
  {
    Message = pmessage;
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
    ( ItestLocation plocation
    )
  {
    Location = plocation;
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
    ( decimal plat
    , decimal plon
    )
  {
    Lat = plat;
    Lon = plon;
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

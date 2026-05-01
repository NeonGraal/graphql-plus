//HintName: test_Samples_Intf.gen.cs
// Generated from {CurrentDirectory}Samples.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Samples;

public interface ItestQuery
  : IGqlpInterfaceBase
{
  ItestFullUser? AsFullUser { get; }
  ItestQueryObject? As_Query { get; }
}

public interface ItestQueryObject
  : IGqlpInterfaceBase
{
  ItestFullUser User { get; }
  ItestFullUser? Call_User(ItestUserFilter parameter);
  ItestStory LikeStory { get; }
  ItestStory? Call_LikeStory(ItestStoryFilter parameter);
  string Field { get; }
  string? Call_Field(ItestFieldFilter parameter);
  ItestFullUser Me { get; }
  string Picture { get; }
  string? Call_Picture(ItestPicFilter parameter);
  ICollection<ItestProfile> Profiles { get; }
  ICollection<ItestProfile>? Call_Profiles(ItestProfileFilter parameter);
  string NearestThing { get; }
  string? Call_NearestThing(ItestThingFilter parameter);
}

public interface ItestMutation
  : IGqlpInterfaceBase
{
  ItestMutationObject? As_Mutation { get; }
}

public interface ItestMutationObject
  : IGqlpInterfaceBase
{
  bool SendEmail { get; }
  bool? Call_SendEmail(ItestEmail parameter);
}

public interface ItestUserFilter
  : IGqlpInterfaceBase
{
  ItestUserFilterObject? As_UserFilter { get; }
}

public interface ItestUserFilterObject
  : IGqlpInterfaceBase
{
  decimal Id { get; }
}

public interface ItestUser
  : IGqlpInterfaceBase
{
  ItestUserObject? As_User { get; }
}

public interface ItestUserObject
  : IGqlpInterfaceBase
{
  decimal Id { get; }
  string Name { get; }
  string FirstName { get; }
  string LastName { get; }
  ItestDate Birthday { get; }
}

public interface ItestFullUser
  : ItestUser
{
  ItestFullUserObject? As_FullUser { get; }
}

public interface ItestFullUserObject
  : ItestUserObject
{
  string ProfilePic { get; }
  string? Call_ProfilePic(ItestPicFilter parameter);
  ItestUserList Friends { get; }
  ItestUserList? Call_Friends(ItestFriendsFilter parameter);
  ItestUserList MutualFriends { get; }
  ItestUserList? Call_MutualFriends(ItestFriendsFilter parameter);
}

public interface ItestUserList
  : IGqlpInterfaceBase
{
  ICollection<ItestUser>? AsUser { get; }
  ItestUserListObject? As_UserList { get; }
}

public interface ItestUserListObject
  : IGqlpInterfaceBase
{
  decimal Count { get; }
  ICollection<ItestUser> Users { get; }
}

public interface ItestStoryFilter
  : IGqlpInterfaceBase
{
  ItestStoryFilterObject? As_StoryFilter { get; }
}

public interface ItestStoryFilterObject
  : IGqlpInterfaceBase
{
  decimal StoryID { get; }
}

public interface ItestStory
  : IGqlpInterfaceBase
{
  ItestStoryObject? As_Story { get; }
}

public interface ItestStoryObject
  : IGqlpInterfaceBase
{
  decimal LikeCount { get; }
}

public interface ItestFieldFilter
  : IGqlpInterfaceBase
{
  ItestFieldFilterObject? As_FieldFilter { get; }
}

public interface ItestFieldFilterObject
  : IGqlpInterfaceBase
{
  string? Arg { get; }
}

public interface ItestPicFilter
  : IGqlpInterfaceBase
{
  ItestPicFilterObject? As_PicFilter { get; }
}

public interface ItestPicFilterObject
  : IGqlpInterfaceBase
{
  decimal Size { get; }
  decimal Width { get; }
  decimal Height { get; }
}

public interface ItestFriendsFilter
  : IGqlpInterfaceBase
{
  ItestFriendsFilterObject? As_FriendsFilter { get; }
}

public interface ItestFriendsFilterObject
  : IGqlpInterfaceBase
{
  decimal First { get; }
}

public interface ItestProfile
  : ItestUser
{
  ItestPage? AsPage { get; }
  ItestProfileObject? As_Profile { get; }
}

public interface ItestProfileObject
  : ItestUserObject
{
  string Handle { get; }
}

public interface ItestProfileFilter
  : IGqlpInterfaceBase
{
  ItestProfileFilterObject? As_ProfileFilter { get; }
}

public interface ItestProfileFilterObject
  : IGqlpInterfaceBase
{
  ICollection<string> Handles { get; }
}

public interface ItestPage
  : IGqlpInterfaceBase
{
  ItestPageObject? As_Page { get; }
}

public interface ItestPageObject
  : IGqlpInterfaceBase
{
  string Handle { get; }
  ItestUserList Likers { get; }
}

public interface ItestIncludeParams
  : IGqlpInterfaceBase
{
  ItestIncludeParamsObject? As_IncludeParams { get; }
}

public interface ItestIncludeParamsObject
  : IGqlpInterfaceBase
{
  bool If { get; }
}

public interface ItestEmail
  : IGqlpInterfaceBase
{
  ItestEmailObject? As_Email { get; }
}

public interface ItestEmailObject
  : IGqlpInterfaceBase
{
  string Message { get; }
}

public interface ItestThingFilter
  : IGqlpInterfaceBase
{
  ItestThingFilterObject? As_ThingFilter { get; }
}

public interface ItestThingFilterObject
  : IGqlpInterfaceBase
{
  ItestLocation Location { get; }
}

public interface ItestLocation
  : IGqlpInterfaceBase
{
  ItestLocationObject? As_Location { get; }
}

public interface ItestLocationObject
  : IGqlpInterfaceBase
{
  decimal Lat { get; }
  decimal Lon { get; }
}

public interface ItestInt
  : IGqlpDomainNumber
{
}

public interface ItestDate
  : IGqlpDomainString
{
}

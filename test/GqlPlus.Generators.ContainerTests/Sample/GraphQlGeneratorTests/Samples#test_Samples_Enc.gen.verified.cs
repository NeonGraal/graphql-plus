//HintName: test_Samples_Enc.gen.cs
// Generated from {CurrentDirectory}Samples.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Samples;

internal class testQueryEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestQueryObject>
{
  private readonly IEncoder<ItestFullUser> _itestFullUser = encoders.EncoderFor<ItestFullUser>();
  private readonly IEncoder<ItestStory> _itestStory = encoders.EncoderFor<ItestStory>();
  private readonly IEncoder<ItestProfile> _itestProfile = encoders.EncoderFor<ItestProfile>();
  public Structured Encode(ItestQueryObject input)
    => Structured.Empty()
      .AddEncoded("user", input.User(), _itestFullUser)
      .AddEncoded("likeStory", input.LikeStory(), _itestStory)
      .Add("field", input.Field())
      .AddEncoded("me", input.Me, _itestFullUser)
      .Add("picture", input.Picture())
      .AddList("profiles", input.Profiles(), _itestProfile)
      .Add("nearestThing", input.NearestThing());

  internal static testQueryEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testMutationEncoder : IEncoder<ItestMutationObject>
{
  public Structured Encode(ItestMutationObject input)
    => Structured.Empty()
      .Add("sendEmail", input.SendEmail());

  internal static testMutationEncoder Factory(IEncoderRepository _) => new();
}

internal class testUserFilterEncoder : IEncoder<ItestUserFilterObject>
{
  public Structured Encode(ItestUserFilterObject input)
    => Structured.Empty()
      .Add("id", input.Id);

  internal static testUserFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testUserEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUserObject>
{
  private readonly IEncoder<ItestDate> _itestDate = encoders.EncoderFor<ItestDate>();
  public Structured Encode(ItestUserObject input)
    => Structured.Empty()
      .Add("id", input.Id)
      .Add("name", input.Name)
      .Add("firstName", input.FirstName)
      .Add("lastName", input.LastName)
      .AddEncoded("birthday", input.Birthday, _itestDate);

  internal static testUserEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFullUserEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFullUserObject>
{
  private readonly IEncoder<ItestUserObject> _itestUser = encoders.EncoderFor<ItestUserObject>();
  private readonly IEncoder<ItestUserList> _itestUserList = encoders.EncoderFor<ItestUserList>();
  public Structured Encode(ItestFullUserObject input)
    => _itestUser.Encode(input)
      .Add("profilePic", input.ProfilePic())
      .AddEncoded("friends", input.Friends(), _itestUserList)
      .AddEncoded("mutualFriends", input.MutualFriends(), _itestUserList);

  internal static testFullUserEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUserListEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUserListObject>
{
  private readonly IEncoder<ItestUser> _itestUser = encoders.EncoderFor<ItestUser>();
  public Structured Encode(ItestUserListObject input)
    => Structured.Empty()
      .Add("count", input.Count)
      .AddList("users", input.Users, _itestUser);

  internal static testUserListEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testStoryFilterEncoder : IEncoder<ItestStoryFilterObject>
{
  public Structured Encode(ItestStoryFilterObject input)
    => Structured.Empty()
      .Add("storyID", input.StoryID);

  internal static testStoryFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testStoryEncoder : IEncoder<ItestStoryObject>
{
  public Structured Encode(ItestStoryObject input)
    => Structured.Empty()
      .Add("likeCount", input.LikeCount);

  internal static testStoryEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldFilterEncoder : IEncoder<ItestFieldFilterObject>
{
  public Structured Encode(ItestFieldFilterObject input)
    => Structured.Empty()
      .AddIf(input.Arg is not null, onTrue: t => t.Add("arg", input.Arg!));

  internal static testFieldFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testPicFilterEncoder : IEncoder<ItestPicFilterObject>
{
  public Structured Encode(ItestPicFilterObject input)
    => Structured.Empty()
      .Add("size", input.Size)
      .Add("width", input.Width)
      .Add("height", input.Height);

  internal static testPicFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testFriendsFilterEncoder : IEncoder<ItestFriendsFilterObject>
{
  public Structured Encode(ItestFriendsFilterObject input)
    => Structured.Empty()
      .Add("first", input.First);

  internal static testFriendsFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testProfileEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestProfileObject>
{
  private readonly IEncoder<ItestUserObject> _itestUser = encoders.EncoderFor<ItestUserObject>();
  public Structured Encode(ItestProfileObject input)
    => _itestUser.Encode(input)
      .Add("handle", input.Handle);

  internal static testProfileEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testProfileFilterEncoder : IEncoder<ItestProfileFilterObject>
{
  public Structured Encode(ItestProfileFilterObject input)
    => Structured.Empty()
      .Add("handles", input.Handles.Encode());

  internal static testProfileFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testPageEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPageObject>
{
  private readonly IEncoder<ItestUserList> _itestUserList = encoders.EncoderFor<ItestUserList>();
  public Structured Encode(ItestPageObject input)
    => Structured.Empty()
      .Add("handle", input.Handle)
      .AddEncoded("likers", input.Likers, _itestUserList);

  internal static testPageEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testIncludeParamsEncoder : IEncoder<ItestIncludeParamsObject>
{
  public Structured Encode(ItestIncludeParamsObject input)
    => Structured.Empty()
      .Add("if", input.If);

  internal static testIncludeParamsEncoder Factory(IEncoderRepository _) => new();
}

internal class testEmailEncoder : IEncoder<ItestEmailObject>
{
  public Structured Encode(ItestEmailObject input)
    => Structured.Empty()
      .Add("message", input.Message);

  internal static testEmailEncoder Factory(IEncoderRepository _) => new();
}

internal class testThingFilterEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestThingFilterObject>
{
  private readonly IEncoder<ItestLocation> _itestLocation = encoders.EncoderFor<ItestLocation>();
  public Structured Encode(ItestThingFilterObject input)
    => Structured.Empty()
      .AddEncoded("location", input.Location, _itestLocation);

  internal static testThingFilterEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testLocationEncoder : IEncoder<ItestLocationObject>
{
  public Structured Encode(ItestLocationObject input)
    => Structured.Empty()
      .Add("lat", input.Lat)
      .Add("lon", input.Lon);

  internal static testLocationEncoder Factory(IEncoderRepository _) => new();
}

internal class testIntEncoder : IEncoder<ItestInt>
{
  public Structured Encode(ItestInt input)
    => new(input.Value);

  internal static testIntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDateEncoder : IEncoder<ItestDate>
{
  public Structured Encode(ItestDate input)
    => new(input.Value);

  internal static testDateEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_SamplesEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_SamplesEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestQueryObject>(testQueryEncoder.Factory)
      .AddEncoder<ItestMutationObject>(testMutationEncoder.Factory)
      .AddEncoder<ItestUserFilterObject>(testUserFilterEncoder.Factory)
      .AddEncoder<ItestUserObject>(testUserEncoder.Factory)
      .AddEncoder<ItestFullUserObject>(testFullUserEncoder.Factory)
      .AddEncoder<ItestUserListObject>(testUserListEncoder.Factory)
      .AddEncoder<ItestStoryFilterObject>(testStoryFilterEncoder.Factory)
      .AddEncoder<ItestStoryObject>(testStoryEncoder.Factory)
      .AddEncoder<ItestFieldFilterObject>(testFieldFilterEncoder.Factory)
      .AddEncoder<ItestPicFilterObject>(testPicFilterEncoder.Factory)
      .AddEncoder<ItestFriendsFilterObject>(testFriendsFilterEncoder.Factory)
      .AddEncoder<ItestProfileObject>(testProfileEncoder.Factory)
      .AddEncoder<ItestProfileFilterObject>(testProfileFilterEncoder.Factory)
      .AddEncoder<ItestPageObject>(testPageEncoder.Factory)
      .AddEncoder<ItestIncludeParamsObject>(testIncludeParamsEncoder.Factory)
      .AddEncoder<ItestEmailObject>(testEmailEncoder.Factory)
      .AddEncoder<ItestThingFilterObject>(testThingFilterEncoder.Factory)
      .AddEncoder<ItestLocationObject>(testLocationEncoder.Factory)
      .AddEncoder<ItestInt>(testIntEncoder.Factory)
      .AddEncoder<ItestDate>(testDateEncoder.Factory);
}

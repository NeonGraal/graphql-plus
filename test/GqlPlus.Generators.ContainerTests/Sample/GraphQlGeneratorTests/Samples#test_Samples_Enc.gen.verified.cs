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
  private readonly Encoder<ItestFullUser> _itestFullUser = encoders.EncoderFor<ItestFullUser>();
  private readonly Encoder<ItestStory> _itestStory = encoders.EncoderFor<ItestStory>();
  private readonly Encoder<ItestProfile> _itestProfile = encoders.EncoderFor<ItestProfile>();
  public IGqlpValue Encode(ItestQueryObject input)
    => new GqlpUnit()
      .AddEncoded("user", input.User(), _itestFullUser)
      .AddEncoded("likeStory", input.LikeStory(), _itestStory)
      .Add("field", input.Field().Encode())
      .AddEncoded("me", input.Me, _itestFullUser)
      .Add("picture", input.Picture().Encode())
      .AddList("profiles", input.Profiles(), _itestProfile)
      .Add("nearestThing", input.NearestThing().Encode());

  internal static testQueryEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testMutationEncoder : IEncoder<ItestMutationObject>
{
  public IGqlpValue Encode(ItestMutationObject input)
    => new GqlpUnit()
      .Add("sendEmail", input.SendEmail().Encode());

  internal static testMutationEncoder Factory(IEncoderRepository _) => new();
}

internal class testUserFilterEncoder : IEncoder<ItestUserFilterObject>
{
  public IGqlpValue Encode(ItestUserFilterObject input)
    => new GqlpUnit()
      .Add("id", input.Id.Encode());

  internal static testUserFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testUserEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUserObject>
{
  private readonly Encoder<ItestDate> _itestDate = encoders.EncoderFor<ItestDate>();
  public IGqlpValue Encode(ItestUserObject input)
    => new GqlpUnit()
      .Add("id", input.Id.Encode())
      .Add("name", input.Name.Encode())
      .Add("firstName", input.FirstName.Encode())
      .Add("lastName", input.LastName.Encode())
      .AddEncoded("birthday", input.Birthday, _itestDate);

  internal static testUserEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFullUserEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFullUserObject>
{
  private readonly Encoder<ItestUserObject> _itestUser = encoders.EncoderFor<ItestUserObject>();
  private readonly Encoder<ItestUserList> _itestUserList = encoders.EncoderFor<ItestUserList>();
  public IGqlpValue Encode(ItestFullUserObject input)
    => _itestUser.Encode(input)
      .Add("profilePic", input.ProfilePic().Encode())
      .AddEncoded("friends", input.Friends(), _itestUserList)
      .AddEncoded("mutualFriends", input.MutualFriends(), _itestUserList);

  internal static testFullUserEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUserListEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUserListObject>
{
  private readonly Encoder<ItestUser> _itestUser = encoders.EncoderFor<ItestUser>();
  public IGqlpValue Encode(ItestUserListObject input)
    => new GqlpUnit()
      .Add("count", input.Count.Encode())
      .AddList("users", input.Users, _itestUser);

  internal static testUserListEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testStoryFilterEncoder : IEncoder<ItestStoryFilterObject>
{
  public IGqlpValue Encode(ItestStoryFilterObject input)
    => new GqlpUnit()
      .Add("storyID", input.StoryID.Encode());

  internal static testStoryFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testStoryEncoder : IEncoder<ItestStoryObject>
{
  public IGqlpValue Encode(ItestStoryObject input)
    => new GqlpUnit()
      .Add("likeCount", input.LikeCount.Encode());

  internal static testStoryEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldFilterEncoder : IEncoder<ItestFieldFilterObject>
{
  public IGqlpValue Encode(ItestFieldFilterObject input)
    => new GqlpUnit()
      .AddIf(input.Arg is not null, onTrue: t => t.Add("arg", input.Arg!.Encode()));

  internal static testFieldFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testPicFilterEncoder : IEncoder<ItestPicFilterObject>
{
  public IGqlpValue Encode(ItestPicFilterObject input)
    => new GqlpUnit()
      .Add("size", input.Size.Encode())
      .Add("width", input.Width.Encode())
      .Add("height", input.Height.Encode());

  internal static testPicFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testFriendsFilterEncoder : IEncoder<ItestFriendsFilterObject>
{
  public IGqlpValue Encode(ItestFriendsFilterObject input)
    => new GqlpUnit()
      .Add("first", input.First.Encode());

  internal static testFriendsFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testProfileEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestProfileObject>
{
  private readonly Encoder<ItestUserObject> _itestUser = encoders.EncoderFor<ItestUserObject>();
  public IGqlpValue Encode(ItestProfileObject input)
    => _itestUser.Encode(input)
      .Add("handle", input.Handle.Encode());

  internal static testProfileEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testProfileFilterEncoder : IEncoder<ItestProfileFilterObject>
{
  public IGqlpValue Encode(ItestProfileFilterObject input)
    => new GqlpUnit()
      .Add("handles", input.Handles.Encode());

  internal static testProfileFilterEncoder Factory(IEncoderRepository _) => new();
}

internal class testPageEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPageObject>
{
  private readonly Encoder<ItestUserList> _itestUserList = encoders.EncoderFor<ItestUserList>();
  public IGqlpValue Encode(ItestPageObject input)
    => new GqlpUnit()
      .Add("handle", input.Handle.Encode())
      .AddEncoded("likers", input.Likers, _itestUserList);

  internal static testPageEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testIncludeParamsEncoder : IEncoder<ItestIncludeParamsObject>
{
  public IGqlpValue Encode(ItestIncludeParamsObject input)
    => new GqlpUnit()
      .Add("if", input.If.Encode());

  internal static testIncludeParamsEncoder Factory(IEncoderRepository _) => new();
}

internal class testEmailEncoder : IEncoder<ItestEmailObject>
{
  public IGqlpValue Encode(ItestEmailObject input)
    => new GqlpUnit()
      .Add("message", input.Message.Encode());

  internal static testEmailEncoder Factory(IEncoderRepository _) => new();
}

internal class testThingFilterEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestThingFilterObject>
{
  private readonly Encoder<ItestLocation> _itestLocation = encoders.EncoderFor<ItestLocation>();
  public IGqlpValue Encode(ItestThingFilterObject input)
    => new GqlpUnit()
      .AddEncoded("location", input.Location, _itestLocation);

  internal static testThingFilterEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testLocationEncoder : IEncoder<ItestLocationObject>
{
  public IGqlpValue Encode(ItestLocationObject input)
    => new GqlpUnit()
      .Add("lat", input.Lat.Encode())
      .Add("lon", input.Lon.Encode());

  internal static testLocationEncoder Factory(IEncoderRepository _) => new();
}

internal class testIntEncoder : IEncoder<ItestInt>
{
  public IGqlpValue Encode(ItestInt input)
    => input.Value!.Encode();

  internal static testIntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDateEncoder : IEncoder<ItestDate>
{
  public IGqlpValue Encode(ItestDate input)
    => input.Value!.Encode();

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

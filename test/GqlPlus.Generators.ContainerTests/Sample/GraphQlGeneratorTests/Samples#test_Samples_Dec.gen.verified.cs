//HintName: test_Samples_Dec.gen.cs
// Generated from {CurrentDirectory}Samples.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Samples;

internal class testUserFilterDecoder : NullDecoder<ItestUserFilterObject>
{
  public decimal Id { get; set; } = default!;

  internal static testUserFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testUserDecoder : NullDecoder<ItestUserObject>
{
  public decimal Id { get; set; } = default!;
  public string Name { get; set; } = default!;
  public string FirstName { get; set; } = default!;
  public string LastName { get; set; } = default!;
  public ItestDate Birthday { get; set; } = default!;

  internal static testUserDecoder Factory(IDecoderRepository _) => new();
}

internal class testStoryFilterDecoder : NullDecoder<ItestStoryFilterObject>
{
  public decimal StoryID { get; set; } = default!;

  internal static testStoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testStoryDecoder : NullDecoder<ItestStoryObject>
{
  public decimal LikeCount { get; set; } = default!;

  internal static testStoryDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldFilterDecoder : NullDecoder<ItestFieldFilterObject>
{
  public string? Arg { get; set; } = default!;

  internal static testFieldFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testPicFilterDecoder : NullDecoder<ItestPicFilterObject>
{
  public decimal Size { get; set; } = default!;
  public decimal Width { get; set; } = default!;
  public decimal Height { get; set; } = default!;

  internal static testPicFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testFriendsFilterDecoder : NullDecoder<ItestFriendsFilterObject>
{
  public decimal First { get; set; } = default!;

  internal static testFriendsFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testProfileFilterDecoder : NullDecoder<ItestProfileFilterObject>
{
  public ICollection<string> Handles { get; set; } = default!;

  internal static testProfileFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testIncludeParamsDecoder : NullDecoder<ItestIncludeParamsObject>
{
  public bool If { get; set; } = default!;

  internal static testIncludeParamsDecoder Factory(IDecoderRepository _) => new();
}

internal class testEmailDecoder : NullDecoder<ItestEmailObject>
{
  public string Message { get; set; } = default!;

  internal static testEmailDecoder Factory(IDecoderRepository _) => new();
}

internal class testThingFilterDecoder : NullDecoder<ItestThingFilterObject>
{
  public ItestLocation Location { get; set; } = default!;

  internal static testThingFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testLocationDecoder : NullDecoder<ItestLocationObject>
{
  public decimal Lat { get; set; } = default!;
  public decimal Lon { get; set; } = default!;

  internal static testLocationDecoder Factory(IDecoderRepository _) => new();
}

internal class testIntDecoder : NullDecoder<ItestInt>
{

  internal static testIntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDateDecoder : NullDecoder<ItestDate>
{

  internal static testDateDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_SamplesDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_SamplesDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUserFilterObject>(testUserFilterDecoder.Factory)
      .AddDecoder<ItestUserObject>(testUserDecoder.Factory)
      .AddDecoder<ItestStoryFilterObject>(testStoryFilterDecoder.Factory)
      .AddDecoder<ItestStoryObject>(testStoryDecoder.Factory)
      .AddDecoder<ItestFieldFilterObject>(testFieldFilterDecoder.Factory)
      .AddDecoder<ItestPicFilterObject>(testPicFilterDecoder.Factory)
      .AddDecoder<ItestFriendsFilterObject>(testFriendsFilterDecoder.Factory)
      .AddDecoder<ItestProfileFilterObject>(testProfileFilterDecoder.Factory)
      .AddDecoder<ItestIncludeParamsObject>(testIncludeParamsDecoder.Factory)
      .AddDecoder<ItestEmailObject>(testEmailDecoder.Factory)
      .AddDecoder<ItestThingFilterObject>(testThingFilterDecoder.Factory)
      .AddDecoder<ItestLocationObject>(testLocationDecoder.Factory)
      .AddDecoder<ItestInt>(testIntDecoder.Factory)
      .AddDecoder<ItestDate>(testDateDecoder.Factory);
}

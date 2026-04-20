//HintName: test_Samples_Dec.gen.cs
// Generated from {CurrentDirectory}Samples.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Samples;

internal class testUserFilterDecoder
{
  public decimal Id { get; set; }

  internal static testUserFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testUserDecoder
{
  public decimal Id { get; set; }
  public string Name { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public ItestDate Birthday { get; set; }

  internal static testUserDecoder Factory(IDecoderRepository _) => new();
}

internal class testStoryFilterDecoder
{
  public decimal StoryID { get; set; }

  internal static testStoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testStoryDecoder
{
  public decimal LikeCount { get; set; }

  internal static testStoryDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldFilterDecoder
{
  public string? Arg { get; set; }

  internal static testFieldFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testPicFilterDecoder
{
  public decimal Size { get; set; }
  public decimal Width { get; set; }
  public decimal Height { get; set; }

  internal static testPicFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testFriendsFilterDecoder
{
  public decimal First { get; set; }

  internal static testFriendsFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testProfileFilterDecoder
{
  public ICollection<string> Handles { get; set; }

  internal static testProfileFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testIncludeParamsDecoder
{
  public bool If { get; set; }

  internal static testIncludeParamsDecoder Factory(IDecoderRepository _) => new();
}

internal class testEmailDecoder
{
  public string Message { get; set; }

  internal static testEmailDecoder Factory(IDecoderRepository _) => new();
}

internal class testThingFilterDecoder
{
  public ItestLocation Location { get; set; }

  internal static testThingFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testLocationDecoder
{
  public decimal Lat { get; set; }
  public decimal Lon { get; set; }

  internal static testLocationDecoder Factory(IDecoderRepository _) => new();
}

internal class testIntDecoder
{

  internal static testIntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDateDecoder
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

//HintName: test_Samples_Dec.gen.cs
// Generated from {CurrentDirectory}Samples.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Samples;

internal class testUserFilterDecoder : IDecoder<ItestUserFilterObject>
{
  public decimal? Id { get; set; }

  public IMessages Decode(IValue input, out ItestUserFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUserFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testUserDecoder : IDecoder<ItestUserObject>
{
  public decimal? Id { get; set; }
  public string? Name { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public ItestDate? Birthday { get; set; }

  public IMessages Decode(IValue input, out ItestUserObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUserDecoder Factory(IDecoderRepository _) => new();
}

internal class testStoryFilterDecoder : IDecoder<ItestStoryFilterObject>
{
  public decimal? StoryID { get; set; }

  public IMessages Decode(IValue input, out ItestStoryFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testStoryFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testStoryDecoder : IDecoder<ItestStoryObject>
{
  public decimal? LikeCount { get; set; }

  public IMessages Decode(IValue input, out ItestStoryObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testStoryDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldFilterDecoder : IDecoder<ItestFieldFilterObject>
{
  public string? Arg { get; set; }

  public IMessages Decode(IValue input, out ItestFieldFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testPicFilterDecoder : IDecoder<ItestPicFilterObject>
{
  public decimal? Size { get; set; }
  public decimal? Width { get; set; }
  public decimal? Height { get; set; }

  public IMessages Decode(IValue input, out ItestPicFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPicFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testFriendsFilterDecoder : IDecoder<ItestFriendsFilterObject>
{
  public decimal? First { get; set; }

  public IMessages Decode(IValue input, out ItestFriendsFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFriendsFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testProfileFilterDecoder : IDecoder<ItestProfileFilterObject>
{
  public ICollection<string>? Handles { get; set; }

  public IMessages Decode(IValue input, out ItestProfileFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testProfileFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testIncludeParamsDecoder : IDecoder<ItestIncludeParamsObject>
{
  public bool? If { get; set; }

  public IMessages Decode(IValue input, out ItestIncludeParamsObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testIncludeParamsDecoder Factory(IDecoderRepository _) => new();
}

internal class testEmailDecoder : IDecoder<ItestEmailObject>
{
  public string? Message { get; set; }

  public IMessages Decode(IValue input, out ItestEmailObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testEmailDecoder Factory(IDecoderRepository _) => new();
}

internal class testThingFilterDecoder : IDecoder<ItestThingFilterObject>
{
  public ItestLocation? Location { get; set; }

  public IMessages Decode(IValue input, out ItestThingFilterObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testThingFilterDecoder Factory(IDecoderRepository _) => new();
}

internal class testLocationDecoder : IDecoder<ItestLocationObject>
{
  public decimal? Lat { get; set; }
  public decimal? Lon { get; set; }

  public IMessages Decode(IValue input, out ItestLocationObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testLocationDecoder Factory(IDecoderRepository _) => new();
}

internal class testIntDecoder : IDecoder<ItestInt>
{

  public IMessages Decode(IValue input, out ItestInt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testIntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDateDecoder : IDecoder<ItestDate>
{

  public IMessages Decode(IValue input, out ItestDate? output)
  {
    output = null;
    return Messages.New;
  }

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

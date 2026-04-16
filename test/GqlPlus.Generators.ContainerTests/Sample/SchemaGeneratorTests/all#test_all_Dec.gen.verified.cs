//HintName: test_all_Dec.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidDecoder
{

  internal static testGuidDecoder Factory(IDecoderRepository _) => new();
}

internal class testOneDecoder
{
  public string Two { get; set; }
  public string Three { get; set; }

  internal static testOneDecoder Factory(IDecoderRepository _) => new();
}

internal class testManyDecoder
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }

  internal static testManyDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDecoder
{
  public ICollection<string> Strings { get; set; }

  internal static testFieldDecoder Factory(IDecoderRepository _) => new();
}

internal class testParamDecoder
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }

  internal static testParamDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_allDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_allDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGuid>(testGuidDecoder.Factory)
      .AddDecoder<testOne>(testOneDecoder.Factory)
      .AddDecoder<ItestMany>(testManyDecoder.Factory)
      .AddDecoder<ItestFieldObject>(testFieldDecoder.Factory)
      .AddDecoder<ItestParamObject>(testParamDecoder.Factory);
}

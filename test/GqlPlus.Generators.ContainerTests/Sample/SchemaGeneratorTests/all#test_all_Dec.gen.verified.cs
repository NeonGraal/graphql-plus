//HintName: test_all_Dec.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidDecoder
{
}

internal class testOneDecoder
{
  public string Two { get; set; }
  public string Three { get; set; }
}

internal class testManyDecoder
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

internal class testFieldDecoder
{
  public ICollection<string> Strings { get; set; }
}

internal class testParamDecoder
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }
}

internal static class test_allDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_allDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGuid>(_ => new testGuidDecoder())
      .AddDecoder<testOne>(_ => new testOneDecoder())
      .AddDecoder<ItestMany>(r => new testManyDecoder(r))
      .AddDecoder<ItestFieldObject>(r => new testFieldDecoder(r))
      .AddDecoder<ItestParamObject>(r => new testParamDecoder(r));
}

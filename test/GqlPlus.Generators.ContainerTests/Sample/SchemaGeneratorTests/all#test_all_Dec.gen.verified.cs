//HintName: test_all_Dec.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidDecoder : NullDecoder<ItestGuid>
{

  internal static testGuidDecoder Factory(IDecoderRepository _) => new();
}

internal class testOneDecoder : NullDecoder<testOne>
{
  public string Two { get; set; } = default!;
  public string Three { get; set; } = default!;

  internal static testOneDecoder Factory(IDecoderRepository _) => new();
}

internal class testManyDecoder : NullDecoder<ItestMany>
{
  public Guid AsGuid { get; set; } = default!;
  public Number AsNumber { get; set; } = default!;

  internal static testManyDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDecoder : NullDecoder<ItestFieldObject>
{
  public ICollection<string> Strings { get; set; } = default!;

  internal static testFieldDecoder Factory(IDecoderRepository _) => new();
}

internal class testParamDecoder : NullDecoder<ItestParamObject>
{
  public ItestMany? AfterId { get; set; } = default!;
  public ItestMany BeforeId { get; set; } = default!;

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

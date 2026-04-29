//HintName: test_Domain_Dec.gen.cs
// Generated from {CurrentDirectory}Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

internal class test_DomainKindDecoder : IDecoder<test_DomainKind?>
{
  public IMessages Decoder(IValue input, out test_DomainKind? output)
    => input.DecodeEnum("_DomainKind", out output);

  internal static test_DomainKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BaseDomainItemDecoder
{
  public bool Exclude { get; set; }

  internal static test_BaseDomainItemDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainTrueFalseDecoder
{
  public bool Value { get; set; }

  internal static test_DomainTrueFalseDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRangeDecoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  internal static test_DomainRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRegexDecoder
{
  public string Pattern { get; set; }

  internal static test_DomainRegexDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_DomainDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DomainDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_DomainKind?>(test_DomainKindDecoder.Factory)
      .AddDecoder<Itest_BaseDomainItemObject>(test_BaseDomainItemDecoder.Factory)
      .AddDecoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseDecoder.Factory)
      .AddDecoder<Itest_DomainRangeObject>(test_DomainRangeDecoder.Factory)
      .AddDecoder<Itest_DomainRegexObject>(test_DomainRegexDecoder.Factory);
}

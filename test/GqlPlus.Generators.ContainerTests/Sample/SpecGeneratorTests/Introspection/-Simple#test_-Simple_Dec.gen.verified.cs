//HintName: test_-Simple_Dec.gen.cs
// Generated from {CurrentDirectory}-Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class test_DomainKindDecoder
{
  public string Boolean { get; set; }
  public string Enum { get; set; }
  public string Number { get; set; }
  public string String { get; set; }

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

internal class test_EnumLabelDecoder
{
  public Itest_Name EnumType { get; set; }

  internal static test_EnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__SimpleDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__SimpleDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_DomainKind>(test_DomainKindDecoder.Factory)
      .AddDecoder<Itest_BaseDomainItemObject>(test_BaseDomainItemDecoder.Factory)
      .AddDecoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseDecoder.Factory)
      .AddDecoder<Itest_DomainRangeObject>(test_DomainRangeDecoder.Factory)
      .AddDecoder<Itest_DomainRegexObject>(test_DomainRegexDecoder.Factory)
      .AddDecoder<Itest_EnumLabelObject>(test_EnumLabelDecoder.Factory);
}

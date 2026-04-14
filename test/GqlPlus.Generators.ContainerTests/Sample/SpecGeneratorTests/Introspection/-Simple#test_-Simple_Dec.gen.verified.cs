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
}

internal class test_BaseDomainItemDecoder
{
  public bool Exclude { get; set; }
}

internal class test_DomainTrueFalseDecoder
{
  public bool Value { get; set; }
}

internal class test_DomainRangeDecoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }
}

internal class test_DomainRegexDecoder
{
  public string Pattern { get; set; }
}

internal class test_EnumLabelDecoder
{
  public Itest_Name EnumType { get; set; }
}

internal static class test__SimpleDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__SimpleDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_DomainKind>(_ => new test_DomainKindDecoder())
      .AddDecoder<Itest_BaseDomainItemObject>(_ => new test_BaseDomainItemDecoder())
      .AddDecoder<Itest_DomainTrueFalseObject>(_ => new test_DomainTrueFalseDecoder())
      .AddDecoder<Itest_DomainRangeObject>(_ => new test_DomainRangeDecoder())
      .AddDecoder<Itest_DomainRegexObject>(_ => new test_DomainRegexDecoder())
      .AddDecoder<Itest_EnumLabelObject>(_ => new test_EnumLabelDecoder());
}

//HintName: test_Domain_Dec.gen.cs
// Generated from {CurrentDirectory}Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

internal class test_DomainKindDecoder
{
  public string Boolean { get; set; }
  public string Enum { get; set; }
  public string Number { get; set; }
  public string String { get; set; }
}

internal class test_DomainRefDecoder<TDomainKind>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainDecoder<TDomainKind,TItem,TDomainItem>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainItemDecoder
{
  public bool Exclude { get; set; }
}

internal class test_DomainItemDecoder<TItem>
{
  public Itest_Name Domain { get; set; }
}

internal class test_DomainValueDecoder<TDomainKind,TValue>
{
  public TValue Value { get; set; }
}

internal class test_BasicValueDecoder
{
}

internal class test_DomainTrueFalseDecoder
{
  public bool Value { get; set; }
}

internal class test_DomainItemTrueFalseDecoder
{
}

internal class test_DomainLabelDecoder
{
  public Itest_EnumValue Label { get; set; }
}

internal class test_DomainItemLabelDecoder
{
}

internal class test_DomainRangeDecoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }
}

internal class test_DomainItemRangeDecoder
{
}

internal class test_DomainRegexDecoder
{
  public string Pattern { get; set; }
}

internal class test_DomainItemRegexDecoder
{
}

internal static class test_DomainDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DomainDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_DomainKind>(_ => new test_DomainKindDecoder())
      .AddDecoder<Itest_BaseDomainItemObject>(r => new test_BaseDomainItemDecoder(r))
      .AddDecoder<Itest_BasicValueObject>(_ => new test_BasicValueDecoder())
      .AddDecoder<Itest_DomainTrueFalseObject>(r => new test_DomainTrueFalseDecoder(r))
      .AddDecoder<Itest_DomainItemTrueFalseObject>(_ => new test_DomainItemTrueFalseDecoder())
      .AddDecoder<Itest_DomainLabelObject>(r => new test_DomainLabelDecoder(r))
      .AddDecoder<Itest_DomainItemLabelObject>(_ => new test_DomainItemLabelDecoder())
      .AddDecoder<Itest_DomainRangeObject>(r => new test_DomainRangeDecoder(r))
      .AddDecoder<Itest_DomainItemRangeObject>(_ => new test_DomainItemRangeDecoder())
      .AddDecoder<Itest_DomainRegexObject>(r => new test_DomainRegexDecoder(r))
      .AddDecoder<Itest_DomainItemRegexObject>(_ => new test_DomainItemRegexDecoder());
}

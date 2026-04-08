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

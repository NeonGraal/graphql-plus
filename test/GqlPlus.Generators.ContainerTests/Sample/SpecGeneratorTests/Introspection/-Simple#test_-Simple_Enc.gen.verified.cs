//HintName: test_-Simple_Enc.gen.cs
// Generated from {CurrentDirectory}-Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class test_DomainKindEncoder
{
  public string Boolean { get; set; }
  public string Enum { get; set; }
  public string Number { get; set; }
  public string String { get; set; }
}

internal class test_DomainRefEncoder<TDomainKind>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainEncoder<TDomainKind,TItem,TDomainItem>
{
  public TDomainKind DomainKind { get; set; }
}

internal class test_BaseDomainItemEncoder
{
  public bool Exclude { get; set; }
}

internal class test_DomainItemEncoder<TItem>
{
  public Itest_Name Domain { get; set; }
}

internal class test_DomainValueEncoder<TDomainKind,TValue>
{
  public TValue Value { get; set; }
}

internal class test_BasicValueEncoder
{
}

internal class test_DomainTrueFalseEncoder
{
  public bool Value { get; set; }
}

internal class test_DomainItemTrueFalseEncoder
{
}

internal class test_DomainLabelEncoder
{
  public Itest_EnumValue Label { get; set; }
}

internal class test_DomainItemLabelEncoder
{
}

internal class test_DomainRangeEncoder
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }
}

internal class test_DomainItemRangeEncoder
{
}

internal class test_DomainRegexEncoder
{
  public string Pattern { get; set; }
}

internal class test_DomainItemRegexEncoder
{
}

internal class test_EnumLabelEncoder
{
  public Itest_Name EnumType { get; set; }
}

internal class test_EnumValueEncoder
{
  public Itest_Name Label { get; set; }
}

internal class test_UnionRefEncoder
{
}

internal class test_UnionMemberEncoder
{
  public Itest_Name Union { get; set; }
}

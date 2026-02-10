//HintName: test_-Simple_Impl.gen.cs
// Generated from -Simple.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class test_DomainRef<Tkind>
  : test_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind DomainKind { get; set; }
  public Itest_DomainRefObject As_DomainRef { get; set; }
}

public class test_BaseDomain<Tdomain,Titem,TdomainItem>
  : test_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain DomainKind { get; set; }
  public Itest_BaseDomainObject As_BaseDomain { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public test_DomainKind Exclude { get; set; }
  public Itest_BaseDomainItemObject As_BaseDomainItem { get; set; }
}

public class test_DomainItem<Titem>
  : testitem
  , Itest_DomainItem<Titem>
{
  public Itest_Name Domain { get; set; }
  public Itest_DomainItemObject As_DomainItem { get; set; }
}

public class test_DomainValue<Tkind,Tvalue>
  : test_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue Value { get; set; }
  public Tvalue Asvalue { get; set; }
  public Itest_DomainValueObject As_DomainValue { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
  public test_DomainKind As_DomainKindBoolean { get; set; }
  public Itest_EnumValue As_EnumValue { get; set; }
  public test_DomainKind As_DomainKindNumber { get; set; }
  public test_DomainKind As_DomainKindString { get; set; }
  public Itest_BasicValueObject As_BasicValue { get; set; }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public test_DomainKind Value { get; set; }
  public Itest_DomainTrueFalseObject As_DomainTrueFalse { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem
  , Itest_DomainItemTrueFalse
{
  public Itest_DomainItemTrueFalseObject As_DomainItemTrueFalse { get; set; }
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public Itest_EnumValue Label { get; set; }
  public Itest_DomainLabelObject As_DomainLabel { get; set; }
}

public class test_DomainItemLabel
  : test_DomainItem
  , Itest_DomainItemLabel
{
  public Itest_DomainItemLabelObject As_DomainItemLabel { get; set; }
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public test_DomainKind? Lower { get; set; }
  public test_DomainKind? Upper { get; set; }
  public Itest_DomainRangeObject As_DomainRange { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem
  , Itest_DomainItemRange
{
  public Itest_DomainItemRangeObject As_DomainItemRange { get; set; }
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public test_DomainKind Pattern { get; set; }
  public Itest_DomainRegexObject As_DomainRegex { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem
  , Itest_DomainItemRegex
{
  public Itest_DomainItemRegexObject As_DomainItemRegex { get; set; }
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_Name Enum { get; set; }
  public Itest_EnumLabelObject As_EnumLabel { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public Itest_Name Label { get; set; }
  public Itest_EnumValueObject As_EnumValue { get; set; }
}

public class test_UnionRef
  : test_TypeRef
  , Itest_UnionRef
{
  public Itest_UnionRefObject As_UnionRef { get; set; }
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_Name Union { get; set; }
  public Itest_UnionMemberObject As_UnionMember { get; set; }
}

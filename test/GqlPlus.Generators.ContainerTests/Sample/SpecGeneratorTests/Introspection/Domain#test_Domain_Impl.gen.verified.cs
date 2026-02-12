//HintName: test_Domain_Impl.gen.cs
// Generated from Domain.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

public class test_DomainRef<TKind>
  : test_TypeRef<Itest_TypeKind>
  , Itest_DomainRef<TKind>
{
  public TKind DomainKind { get; set; }
  public Itest_DomainRefObject<TKind> As_DomainRef { get; set; }
}

public class test_BaseDomain<TDomain,TItem,TDomainItem>
  : test_ParentType<Itest_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomain<TDomain,TItem,TDomainItem>
{
  public TDomain DomainKind { get; set; }
  public Itest_BaseDomainObject<TDomain,TItem,TDomainItem> As_BaseDomain { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public test_DomainKind Exclude { get; set; }
  public Itest_BaseDomainItemObject As_BaseDomainItem { get; set; }
}

public class test_DomainItem<TItem>
  : Itest_DomainItem<TItem>
{
  public Itest_Name Domain { get; set; }
  public TItem AsParent { get; set; }
  public Itest_DomainItemObject<TItem> As_DomainItem { get; set; }
}

public class test_DomainValue<TKind,TValue>
  : test_DomainRef<TKind>
  , Itest_DomainValue<TKind,TValue>
{
  public TValue Value { get; set; }
  public TValue Asvalue { get; set; }
  public Itest_DomainValueObject<TKind,TValue> As_DomainValue { get; set; }
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
  : test_DomainItem<Itest_DomainTrueFalse>
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
  : test_DomainItem<Itest_DomainLabel>
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
  : test_DomainItem<Itest_DomainRange>
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
  : test_DomainItem<Itest_DomainRegex>
  , Itest_DomainItemRegex
{
  public Itest_DomainItemRegexObject As_DomainItemRegex { get; set; }
}

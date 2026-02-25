//HintName: test_Domain_Impl.gen.cs
// Generated from {CurrentDirectory}Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

public class test_DomainRef<TKind>
  : test_TypeRef<Itest_TypeKind>
  , Itest_DomainRef<TKind>
{
  public Itest_DomainRefObject<TKind>? As__DomainRef { get; set; }
}

public class test_DomainRefObject<TKind>
  : test_TypeRefObject<Itest_TypeKind>
  , Itest_DomainRefObject<TKind>
{
  public TKind DomainKind { get; set; }

  public test_DomainRefObject(TKind domainKind)
  {
    DomainKind = domainKind;
  }
}

public class test_BaseDomain<TDomain,TItem,TDomainItem>
  : test_ParentType<Itest_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomain<TDomain,TItem,TDomainItem>
{
  public Itest_BaseDomainObject<TDomain,TItem,TDomainItem>? As__BaseDomain { get; set; }
}

public class test_BaseDomainObject<TDomain,TItem,TDomainItem>
  : test_ParentTypeObject<Itest_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomainObject<TDomain,TItem,TDomainItem>
{
  public TDomain DomainKind { get; set; }

  public test_BaseDomainObject(TDomain domainKind)
  {
    DomainKind = domainKind;
  }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public Itest_BaseDomainItemObject? As__BaseDomainItem { get; set; }
}

public class test_BaseDomainItemObject
  : test_DescribedObject
  , Itest_BaseDomainItemObject
{
  public test_DomainKind Exclude { get; set; }

  public test_BaseDomainItemObject(test_DomainKind exclude)
  {
    Exclude = exclude;
  }
}

public class test_DomainItem<TItem>
  : GqlpModelImplementationBase
  , Itest_DomainItem<TItem>
{
  public TItem? As_Parent { get; set; }
  public Itest_DomainItemObject<TItem>? As__DomainItem { get; set; }
}

public class test_DomainItemObject<TItem>
  : GqlpModelImplementationBase
  , Itest_DomainItemObject<TItem>
{
  public Itest_Name Domain { get; set; }

  public test_DomainItemObject(Itest_Name domain)
  {
    Domain = domain;
  }
}

public class test_DomainValue<TKind,TValue>
  : test_DomainRef<TKind>
  , Itest_DomainValue<TKind,TValue>
{
  public TValue? Asvalue { get; set; }
  public Itest_DomainValueObject<TKind,TValue>? As__DomainValue { get; set; }
}

public class test_DomainValueObject<TKind,TValue>
  : test_DomainRefObject<TKind>
  , Itest_DomainValueObject<TKind,TValue>
{
  public TValue Value { get; set; }

  public test_DomainValueObject(TKind domainKind, TValue value)
    : base(domainKind)
  {
    Value = value;
  }
}

public class test_BasicValue
  : GqlpModelImplementationBase
  , Itest_BasicValue
{
  public test_DomainKind? As_DomainKindBoolean { get; set; }
  public Itest_EnumValue? As_EnumValue { get; set; }
  public test_DomainKind? As_DomainKindNumber { get; set; }
  public test_DomainKind? As_DomainKindString { get; set; }
  public Itest_BasicValueObject? As__BasicValue { get; set; }
}

public class test_BasicValueObject
  : GqlpModelImplementationBase
  , Itest_BasicValueObject
{

  public test_BasicValueObject()
  {
  }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public Itest_DomainTrueFalseObject? As__DomainTrueFalse { get; set; }
}

public class test_DomainTrueFalseObject
  : test_BaseDomainItemObject
  , Itest_DomainTrueFalseObject
{
  public test_DomainKind Value { get; set; }

  public test_DomainTrueFalseObject(test_DomainKind exclude, test_DomainKind value)
    : base(exclude)
  {
    Value = value;
  }
}

public class test_DomainItemTrueFalse
  : test_DomainItem<Itest_DomainTrueFalse>
  , Itest_DomainItemTrueFalse
{
  public Itest_DomainItemTrueFalseObject? As__DomainItemTrueFalse { get; set; }
}

public class test_DomainItemTrueFalseObject
  : test_DomainItemObject<Itest_DomainTrueFalse>
  , Itest_DomainItemTrueFalseObject
{

  public test_DomainItemTrueFalseObject(Itest_Name domain)
    : base(domain)
  {
  }
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public Itest_DomainLabelObject? As__DomainLabel { get; set; }
}

public class test_DomainLabelObject
  : test_BaseDomainItemObject
  , Itest_DomainLabelObject
{
  public Itest_EnumValue Label { get; set; }

  public test_DomainLabelObject(test_DomainKind exclude, Itest_EnumValue label)
    : base(exclude)
  {
    Label = label;
  }
}

public class test_DomainItemLabel
  : test_DomainItem<Itest_DomainLabel>
  , Itest_DomainItemLabel
{
  public Itest_DomainItemLabelObject? As__DomainItemLabel { get; set; }
}

public class test_DomainItemLabelObject
  : test_DomainItemObject<Itest_DomainLabel>
  , Itest_DomainItemLabelObject
{

  public test_DomainItemLabelObject(Itest_Name domain)
    : base(domain)
  {
  }
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public Itest_DomainRangeObject? As__DomainRange { get; set; }
}

public class test_DomainRangeObject
  : test_BaseDomainItemObject
  , Itest_DomainRangeObject
{
  public test_DomainKind? Lower { get; set; }
  public test_DomainKind? Upper { get; set; }

  public test_DomainRangeObject(test_DomainKind exclude)
    : base(exclude)
  {
  }
}

public class test_DomainItemRange
  : test_DomainItem<Itest_DomainRange>
  , Itest_DomainItemRange
{
  public Itest_DomainItemRangeObject? As__DomainItemRange { get; set; }
}

public class test_DomainItemRangeObject
  : test_DomainItemObject<Itest_DomainRange>
  , Itest_DomainItemRangeObject
{

  public test_DomainItemRangeObject(Itest_Name domain)
    : base(domain)
  {
  }
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public Itest_DomainRegexObject? As__DomainRegex { get; set; }
}

public class test_DomainRegexObject
  : test_BaseDomainItemObject
  , Itest_DomainRegexObject
{
  public test_DomainKind Pattern { get; set; }

  public test_DomainRegexObject(test_DomainKind exclude, test_DomainKind pattern)
    : base(exclude)
  {
    Pattern = pattern;
  }
}

public class test_DomainItemRegex
  : test_DomainItem<Itest_DomainRegex>
  , Itest_DomainItemRegex
{
  public Itest_DomainItemRegexObject? As__DomainItemRegex { get; set; }
}

public class test_DomainItemRegexObject
  : test_DomainItemObject<Itest_DomainRegex>
  , Itest_DomainItemRegexObject
{

  public test_DomainItemRegexObject(Itest_Name domain)
    : base(domain)
  {
  }
}

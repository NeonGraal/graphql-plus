//HintName: test_-Simple_Model.gen.cs
// Generated from {CurrentDirectory}-Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public class test_DomainRef<TDomainKind>
  : test_TypeRef<Itest_TypeKind>
  , Itest_DomainRef<TDomainKind>
{
  public Itest_DomainRefObject<TDomainKind>? As__DomainRef { get; set; }
}

public class test_DomainRefObject<TDomainKind>
  : test_TypeRefObject<Itest_TypeKind>
  , Itest_DomainRefObject<TDomainKind>
{
  public TDomainKind DomainKind { get; set; }

  public test_DomainRefObject
    ( TDomainKind domainKind
    )
  {
    DomainKind = domainKind;
  }
}

public class test_BaseDomain<TDomainKind,TItem,TDomainItem>
  : test_ParentType<Itest_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomain<TDomainKind,TItem,TDomainItem>
{
  public Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>? As__BaseDomain { get; set; }
}

public class test_BaseDomainObject<TDomainKind,TItem,TDomainItem>
  : test_ParentTypeObject<Itest_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>
{
  public TDomainKind DomainKind { get; set; }

  public test_BaseDomainObject
    ( TDomainKind domainKind
    )
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
  public bool Exclude { get; set; }

  public test_BaseDomainItemObject
    ( bool exclude
    )
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

  public test_DomainItemObject
    ( Itest_Name domain
    )
  {
    Domain = domain;
  }
}

public class test_DomainValue<TDomainKind,TValue>
  : test_DomainRef<TDomainKind>
  , Itest_DomainValue<TDomainKind,TValue>
{
  public TValue? Asvalue { get; set; }
  public Itest_DomainValueObject<TDomainKind,TValue>? As__DomainValue { get; set; }
}

public class test_DomainValueObject<TDomainKind,TValue>
  : test_DomainRefObject<TDomainKind>
  , Itest_DomainValueObject<TDomainKind,TValue>
{
  public TValue Value { get; set; }

  public test_DomainValueObject
    ( TDomainKind domainKind
    , TValue value
    ) : base(domainKind)
  {
    Value = value;
  }
}

public class test_BasicValue
  : GqlpModelImplementationBase
  , Itest_BasicValue
{
  public bool? AsBoolean { get; set; }
  public Itest_EnumValue? As_EnumValue { get; set; }
  public decimal? AsNumber { get; set; }
  public string? AsString { get; set; }
  public Itest_BasicValueObject? As__BasicValue { get; set; }
}

public class test_BasicValueObject
  : GqlpModelImplementationBase
  , Itest_BasicValueObject
{
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
  public bool Value { get; set; }

  public test_DomainTrueFalseObject
    ( bool exclude
    , bool value
    ) : base(exclude)
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

  public test_DomainItemTrueFalseObject
    ( Itest_Name domain
    ) : base(domain)
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

  public test_DomainLabelObject
    ( bool exclude
    , Itest_EnumValue label
    ) : base(exclude)
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

  public test_DomainItemLabelObject
    ( Itest_Name domain
    ) : base(domain)
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
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  public test_DomainRangeObject
    ( bool exclude
    ) : base(exclude)
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

  public test_DomainItemRangeObject
    ( Itest_Name domain
    ) : base(domain)
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
  public string Pattern { get; set; }

  public test_DomainRegexObject
    ( bool exclude
    , string pattern
    ) : base(exclude)
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

  public test_DomainItemRegexObject
    ( Itest_Name domain
    ) : base(domain)
  {
  }
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_EnumLabelObject? As__EnumLabel { get; set; }
}

public class test_EnumLabelObject
  : test_AliasedObject
  , Itest_EnumLabelObject
{
  public Itest_Name EnumType { get; set; }

  public test_EnumLabelObject
    ( Itest_Name enumType
    )
  {
    EnumType = enumType;
  }
}

public class test_EnumValue
  : test_TypeRef<Itest_TypeKind>
  , Itest_EnumValue
{
  public Itest_EnumValueObject? As__EnumValue { get; set; }
}

public class test_EnumValueObject
  : test_TypeRefObject<Itest_TypeKind>
  , Itest_EnumValueObject
{
  public Itest_Name Label { get; set; }

  public test_EnumValueObject
    ( Itest_Name label
    )
  {
    Label = label;
  }
}

public class test_UnionRef
  : test_TypeRef<Itest_SimpleKind>
  , Itest_UnionRef
{
  public Itest_UnionRefObject? As__UnionRef { get; set; }
}

public class test_UnionRefObject
  : test_TypeRefObject<Itest_SimpleKind>
  , Itest_UnionRefObject
{
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_UnionMemberObject? As__UnionMember { get; set; }
}

public class test_UnionMemberObject
  : test_UnionRefObject
  , Itest_UnionMemberObject
{
  public Itest_Name Union { get; set; }

  public test_UnionMemberObject
    ( Itest_Name union
    )
  {
    Union = union;
  }
}

//HintName: test_Domain_Model.gen.cs
// Generated from {CurrentDirectory}Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

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
    ( TDomainKind pdomainKind
    )
  {
    DomainKind = pdomainKind;
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
    ( TDomainKind pdomainKind
    )
  {
    DomainKind = pdomainKind;
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
    ( bool pexclude
    )
  {
    Exclude = pexclude;
  }
}

public class test_DomainItem<TItem>
  : GqlpModelBase
  , Itest_DomainItem<TItem>
{
  public TItem? As_Parent { get; set; }
  public Itest_DomainItemObject<TItem>? As__DomainItem { get; set; }
}

public class test_DomainItemObject<TItem>
  : GqlpModelBase
  , Itest_DomainItemObject<TItem>
{
  public Itest_Name Domain { get; set; }

  public test_DomainItemObject
    ( Itest_Name pdomain
    )
  {
    Domain = pdomain;
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
    ( TDomainKind pdomainKind
    , TValue pvalue
    ) : base(pdomainKind)
  {
    Value = pvalue;
  }
}

public class test_BasicValue
  : GqlpModelBase
  , Itest_BasicValue
{
  public bool? AsBoolean { get; set; }
  public Itest_EnumValue? As_EnumValue { get; set; }
  public decimal? AsNumber { get; set; }
  public string? AsString { get; set; }
  public Itest_BasicValueObject? As__BasicValue { get; set; }
}

public class test_BasicValueObject
  : GqlpModelBase
  , Itest_BasicValueObject
{

  public test_BasicValueObject
    ()
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
  public bool Value { get; set; }

  public test_DomainTrueFalseObject
    ( bool pexclude
    , bool pvalue
    ) : base(pexclude)
  {
    Value = pvalue;
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
    ( Itest_Name pdomain
    ) : base(pdomain)
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
    ( bool pexclude
    , Itest_EnumValue plabel
    ) : base(pexclude)
  {
    Label = plabel;
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
    ( Itest_Name pdomain
    ) : base(pdomain)
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
    ( bool pexclude
    ) : base(pexclude)
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
    ( Itest_Name pdomain
    ) : base(pdomain)
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
    ( bool pexclude
    , string ppattern
    ) : base(pexclude)
  {
    Pattern = ppattern;
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
    ( Itest_Name pdomain
    ) : base(pdomain)
  {
  }
}

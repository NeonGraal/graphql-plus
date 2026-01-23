//HintName: test_Domain_Intf.gen.cs
// Generated from Domain.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  public test_DomainRef _DomainRef { get; set; }
}

public interface Itest_DomainRefObject<Tkind>
  : Itest_TypeRefObject
{
  public Tkind domainKind { get; set; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  public test_BaseDomain _BaseDomain { get; set; }
}

public interface Itest_BaseDomainObject<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeObject
{
  public Tdomain domainKind { get; set; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  public test_BaseDomainItem _BaseDomainItem { get; set; }
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  public test_DomainKind exclude { get; set; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  public test_DomainItem _DomainItem { get; set; }
}

public interface Itest_DomainItemObject<Titem>
  : ItestitemObject
{
  public test_Name domain { get; set; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  public Tvalue Asvalue { get; set; }
  public test_DomainValue _DomainValue { get; set; }
}

public interface Itest_DomainValueObject<Tkind,Tvalue>
  : Itest_DomainRefObject
{
  public Tvalue value { get; set; }
}

public interface Itest_BasicValue
{
  public test_DomainKind As_DomainKindBoolean { get; set; }
  public test_EnumValue As_EnumValue { get; set; }
  public test_DomainKind As_DomainKindNumber { get; set; }
  public test_DomainKind As_DomainKindString { get; set; }
  public test_BasicValue _BasicValue { get; set; }
}

public interface Itest_BasicValueObject
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  public test_DomainTrueFalse _DomainTrueFalse { get; set; }
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  public test_DomainKind value { get; set; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
  public test_DomainItemTrueFalse _DomainItemTrueFalse { get; set; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  public test_DomainLabel _DomainLabel { get; set; }
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  public test_EnumValue label { get; set; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
  public test_DomainItemLabel _DomainItemLabel { get; set; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  public test_DomainRange _DomainRange { get; set; }
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  public test_DomainKind? lower { get; set; }
  public test_DomainKind? upper { get; set; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
  public test_DomainItemRange _DomainItemRange { get; set; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  public test_DomainRegex _DomainRegex { get; set; }
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  public test_DomainKind pattern { get; set; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
  public test_DomainItemRegex _DomainItemRegex { get; set; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject
{
}

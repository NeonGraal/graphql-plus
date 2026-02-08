//HintName: test_Domain_Intf.gen.cs
// Generated from Domain.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  public Itest_DomainRefObject As_DomainRef { get; set; }
}

public interface Itest_DomainRefObject<Tkind>
  : Itest_TypeRefObject
{
  public Tkind DomainKind { get; set; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  public Itest_BaseDomainObject As_BaseDomain { get; set; }
}

public interface Itest_BaseDomainObject<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeObject
{
  public Tdomain DomainKind { get; set; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  public Itest_BaseDomainItemObject As_BaseDomainItem { get; set; }
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  public Itest_DomainKind Exclude { get; set; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  public Itest_DomainItemObject As_DomainItem { get; set; }
}

public interface Itest_DomainItemObject<Titem>
  : ItestitemObject
{
  public Itest_Name Domain { get; set; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  public Tvalue Asvalue { get; set; }
  public Itest_DomainValueObject As_DomainValue { get; set; }
}

public interface Itest_DomainValueObject<Tkind,Tvalue>
  : Itest_DomainRefObject
{
  public Tvalue Value { get; set; }
}

public interface Itest_BasicValue
{
  public Itest_DomainKind As_DomainKindBoolean { get; set; }
  public Itest_EnumValue As_EnumValue { get; set; }
  public Itest_DomainKind As_DomainKindNumber { get; set; }
  public Itest_DomainKind As_DomainKindString { get; set; }
  public Itest_BasicValueObject As_BasicValue { get; set; }
}

public interface Itest_BasicValueObject
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  public Itest_DomainTrueFalseObject As_DomainTrueFalse { get; set; }
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind Value { get; set; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
  public Itest_DomainItemTrueFalseObject As_DomainItemTrueFalse { get; set; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  public Itest_DomainLabelObject As_DomainLabel { get; set; }
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  public Itest_EnumValue Label { get; set; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
  public Itest_DomainItemLabelObject As_DomainItemLabel { get; set; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  public Itest_DomainRangeObject As_DomainRange { get; set; }
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind? Lower { get; set; }
  public Itest_DomainKind? Upper { get; set; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
  public Itest_DomainItemRangeObject As_DomainItemRange { get; set; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  public Itest_DomainRegexObject As_DomainRegex { get; set; }
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind Pattern { get; set; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
  public Itest_DomainItemRegexObject As_DomainItemRegex { get; set; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject
{
}

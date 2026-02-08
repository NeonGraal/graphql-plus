//HintName: test_-Simple_Intf.gen.cs
// Generated from -Simple.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
}

public interface Itest_DomainRefObject<Tkind>
  : Itest_TypeRefObject
{
  public Tkind DomainKind { get; set; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
}

public interface Itest_BaseDomainObject<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeObject
{
  public Tdomain DomainKind { get; set; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  public Itest_DomainKind Exclude { get; set; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
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
}

public interface Itest_BasicValueObject
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind Value { get; set; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  public Itest_EnumValue Label { get; set; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
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
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind Pattern { get; set; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  public Itest_Name Enum { get; set; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  public Itest_Name Union { get; set; }
}

//HintName: test_-Simple_Intf.gen.cs
// Generated from -Simple.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  public test_DomainRef _DomainRef { get; set; }
}

public interface Itest_DomainRefField<Tkind>
  : Itest_TypeRefField
{
  public Tkind domainKind { get; set; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  public test_BaseDomain _BaseDomain { get; set; }
}

public interface Itest_BaseDomainField<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeField
{
  public Tdomain domainKind { get; set; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  public test_BaseDomainItem _BaseDomainItem { get; set; }
}

public interface Itest_BaseDomainItemField
  : Itest_DescribedField
{
  public test_DomainKind exclude { get; set; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  public test_DomainItem _DomainItem { get; set; }
}

public interface Itest_DomainItemField<Titem>
  : ItestitemField
{
  public test_Identifier domain { get; set; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  public Tvalue Asvalue { get; set; }
  public test_DomainValue _DomainValue { get; set; }
}

public interface Itest_DomainValueField<Tkind,Tvalue>
  : Itest_DomainRefField
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

public interface Itest_BasicValueField
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  public test_DomainTrueFalse _DomainTrueFalse { get; set; }
}

public interface Itest_DomainTrueFalseField
  : Itest_BaseDomainItemField
{
  public test_DomainKind value { get; set; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
  public test_DomainItemTrueFalse _DomainItemTrueFalse { get; set; }
}

public interface Itest_DomainItemTrueFalseField
  : Itest_DomainItemField
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  public test_DomainLabel _DomainLabel { get; set; }
}

public interface Itest_DomainLabelField
  : Itest_BaseDomainItemField
{
  public test_EnumValue label { get; set; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
  public test_DomainItemLabel _DomainItemLabel { get; set; }
}

public interface Itest_DomainItemLabelField
  : Itest_DomainItemField
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  public test_DomainRange _DomainRange { get; set; }
}

public interface Itest_DomainRangeField
  : Itest_BaseDomainItemField
{
  public test_DomainKind? lower { get; set; }
  public test_DomainKind? upper { get; set; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
  public test_DomainItemRange _DomainItemRange { get; set; }
}

public interface Itest_DomainItemRangeField
  : Itest_DomainItemField
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  public test_DomainRegex _DomainRegex { get; set; }
}

public interface Itest_DomainRegexField
  : Itest_BaseDomainItemField
{
  public test_DomainKind pattern { get; set; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
  public test_DomainItemRegex _DomainItemRegex { get; set; }
}

public interface Itest_DomainItemRegexField
  : Itest_DomainItemField
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
  public test_EnumLabel _EnumLabel { get; set; }
}

public interface Itest_EnumLabelField
  : Itest_AliasedField
{
  public test_Identifier enum { get; set; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  public test_EnumValue _EnumValue { get; set; }
}

public interface Itest_EnumValueField
  : Itest_TypeRefField
{
  public test_Identifier label { get; set; }
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
  public test_UnionRef _UnionRef { get; set; }
}

public interface Itest_UnionRefField
  : Itest_TypeRefField
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  public test_UnionMember _UnionMember { get; set; }
}

public interface Itest_UnionMemberField
  : Itest_UnionRefField
{
  public test_Identifier union { get; set; }
}

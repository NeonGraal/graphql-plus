//HintName: test_Domain_Intf.gen.cs
// Generated from Domain.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

public interface Itest_DomainRef<TKind>
  : Itest_TypeRef<Itest_TypeKind>
{
  Itest_DomainRefObject<TKind> As_DomainRef { get; }
}

public interface Itest_DomainRefObject<TKind>
  : Itest_TypeRefObject<Itest_TypeKind>
{
  TKind DomainKind { get; }
}

public interface Itest_BaseDomain<TDomain,TItem,TDomainItem>
  : Itest_ParentType<Itest_TypeKind, TItem, TDomainItem>
{
  Itest_BaseDomainObject<TDomain,TItem,TDomainItem> As_BaseDomain { get; }
}

public interface Itest_BaseDomainObject<TDomain,TItem,TDomainItem>
  : Itest_ParentTypeObject<Itest_TypeKind, TItem, TDomainItem>
{
  TDomain DomainKind { get; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  Itest_BaseDomainItemObject As_BaseDomainItem { get; }
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  test_DomainKind Exclude { get; }
}

public interface Itest_DomainItem<TItem>
  : Itestitem
{
  Itest_DomainItemObject<TItem> As_DomainItem { get; }
}

public interface Itest_DomainItemObject<TItem>
  : ItestitemObject
{
  Itest_Name Domain { get; }
}

public interface Itest_DomainValue<TKind,TValue>
  : Itest_DomainRef<TKind>
{
  TValue Asvalue { get; }
  Itest_DomainValueObject<TKind,TValue> As_DomainValue { get; }
}

public interface Itest_DomainValueObject<TKind,TValue>
  : Itest_DomainRefObject<TKind>
{
  TValue Value { get; }
}

public interface Itest_BasicValue
{
  test_DomainKind As_DomainKindBoolean { get; }
  Itest_EnumValue As_EnumValue { get; }
  test_DomainKind As_DomainKindNumber { get; }
  test_DomainKind As_DomainKindString { get; }
  Itest_BasicValueObject As_BasicValue { get; }
}

public interface Itest_BasicValueObject
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  Itest_DomainTrueFalseObject As_DomainTrueFalse { get; }
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  test_DomainKind Value { get; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem<Itest_DomainTrueFalse>
{
  Itest_DomainItemTrueFalseObject As_DomainItemTrueFalse { get; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject<Itest_DomainTrueFalse>
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  Itest_DomainLabelObject As_DomainLabel { get; }
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  Itest_EnumValue Label { get; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem<Itest_DomainLabel>
{
  Itest_DomainItemLabelObject As_DomainItemLabel { get; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject<Itest_DomainLabel>
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  Itest_DomainRangeObject As_DomainRange { get; }
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  test_DomainKind? Lower { get; }
  test_DomainKind? Upper { get; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem<Itest_DomainRange>
{
  Itest_DomainItemRangeObject As_DomainItemRange { get; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject<Itest_DomainRange>
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  Itest_DomainRegexObject As_DomainRegex { get; }
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  test_DomainKind Pattern { get; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem<Itest_DomainRegex>
{
  Itest_DomainItemRegexObject As_DomainItemRegex { get; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject<Itest_DomainRegex>
{
}
